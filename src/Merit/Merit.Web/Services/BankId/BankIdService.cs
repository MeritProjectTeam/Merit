using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Merit.Web.Services.BankId
{
    public class BankIdService
    {
        private static readonly MediaTypeHeaderValue jsonContentHeader = new MediaTypeHeaderValue(@"application/json");

        private readonly HttpClientHandler clientHandler;
        private readonly HttpClient httpClient;
        private readonly X509Certificate2 localCert;

        public BankIdService(string certFile, string certPass, Uri baseAddress)
        {
            localCert = new X509Certificate2(certFile, certPass);

            clientHandler = new();
            clientHandler.ClientCertificates.Add(localCert);
            clientHandler.ServerCertificateCustomValidationCallback = ValidateServerCertificate;

            httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = baseAddress;
            httpClient.DefaultRequestVersion = HttpVersion.Version11; // Default value, but made explicit for this API.
        }

        public async Task<IBankIdResponse> AuthorizeAsync(string personalNr, string userIp)
        {
            HttpResponseMessage response = await PostToBankId("auth", new
            {
                personalNumber = personalNr,
                endUserIp = userIp
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AuthResponse>();
            }

            return await ParseErrorAsync(response);
        }

        /// <summary>
        /// Collects the result of a sign or auth order using the orderRef as reference. RP should keep on calling
        /// collect every two seconds as long as status indicates pending. RP must abort if status indicates failed. The
        /// user identity is returned when complete.
        /// </summary>
        /// <param name="orderRef"></param>
        /// <returns></returns>
        public async Task<IBankIdResponse> CollectAsync(Guid orderRef)
        {
            HttpResponseMessage response = await PostToBankId("collect", new
            {
                orderRef = orderRef.ToString("D")
            });

            if (response.IsSuccessStatusCode)
            {
                var collectResponse = await response.Content.ReadFromJsonAsync<CollectResponse>();
                return ParseCollectResponse(collectResponse);
            }

            return await ParseErrorAsync(response);
        }

        public async Task<IBankIdResponse> CancelAsync(Guid orderRef)
        {
            HttpResponseMessage response = await PostToBankId("cancel", new
            {
                orderRef = orderRef.ToString("D")
            });

            if (response.IsSuccessStatusCode)
            {
                return new EmptyResponse();
            }

            return await ParseErrorAsync(response);
        }

        private IBankIdResponse ParseCollectResponse(CollectResponse collectResponse)
        {
            MessageCode messageCode = collectResponse.Status switch
            {
                "pending" => collectResponse.HintCode switch
                {
                    "outstandingTransaction" => MessageCode.RFA1,
                    "noClient" => MessageCode.RFA1,
                    "started" => MessageCode.RFA14A,
                    "userSign" => MessageCode.RFA9,
                    _ => MessageCode.RFA21
                },
                "failed" => collectResponse.HintCode switch
                {
                    "expiredTransaction" => MessageCode.RFA8,
                    "certificateErr" => MessageCode.RFA16,
                    "userCancel" => MessageCode.RFA6,
                    "cancelled" => MessageCode.RFA3,
                    "startFailed" => MessageCode.RFA17A,
                    _ => MessageCode.RFA21
                },
                "complete" => MessageCode.None,
                _ => throw new BankIdException("Unknown status response from server.")
            };

            return collectResponse with { MessageCode = messageCode };
        }

        protected virtual bool ValidateServerCertificate(HttpRequestMessage requestMessage,
                                                         X509Certificate2 cert,
                                                         X509Chain chain,
                                                         SslPolicyErrors errors) => errors == SslPolicyErrors.None;

        private async Task<ErrorResponse> ParseErrorAsync(HttpResponseMessage response)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            var messageCode = response.StatusCode switch
            {
                HttpStatusCode.BadRequest => error.ErrorCode switch
                {
                    "alreadyInProgress" => MessageCode.RFA4,
                    "invalidParameters" => throw new BankIdException("Invalid parameter, method usage, or stale 'orderRef' parameter."),
                    _ => MessageCode.RFA22
                },
                HttpStatusCode.Unauthorized
                or HttpStatusCode.Forbidden => throw new BankIdException("RP does not have access to the service."),
                HttpStatusCode.NotFound => throw new BankIdException("An erroneouslyURLpathwas used."),
                HttpStatusCode.MethodNotAllowed => throw new BankIdException("Only http method POST is allowed."),
                HttpStatusCode.RequestTimeout => MessageCode.RFA5,
                HttpStatusCode.UnsupportedMediaType => throw new BankIdException("Invalid use of 'charset' parameter in content-type header."),
                HttpStatusCode.InternalServerError => MessageCode.RFA5,
                HttpStatusCode.ServiceUnavailable => MessageCode.RFA5,
                _ => throw new BankIdException("An unhandled status code was returned from server, or there was no error to parse.")
            };

            return error with { MessageCode = messageCode };
        }

        private Task<HttpResponseMessage> PostToBankId(string requestUri, object data)
        {
            JsonContent content = JsonContent.Create(data);
            content.Headers.ContentType = jsonContentHeader;
            return httpClient.PostAsync(requestUri, content);
        }
    }
}