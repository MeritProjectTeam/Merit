using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace Merit.Web.Services.BankId
{
    public abstract class BankIdServiceBase
    {
        private static readonly MediaTypeHeaderValue jsonContentHeader = new MediaTypeHeaderValue(@"application/json");

        private readonly X509Certificate2 localCert;
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler clientHandler;

        protected BankIdServiceBase(string certFile, string certPass, Uri baseAddress)
        {
            localCert = new X509Certificate2(certFile, certPass);

            clientHandler = new();
            clientHandler.ClientCertificates.Add(localCert);
            clientHandler.ServerCertificateCustomValidationCallback = ValidateServerCertificate;

            httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = baseAddress;
            httpClient.DefaultRequestVersion = HttpVersion.Version11; // Default value, but made explicit for this API.
        }

        public async Task<IBankIdResponse> BeginAuthorizeAsync(string personalNr, string userIp)
        {
            JsonContent content = JsonContent.Create(new
            {
                personalNumber = personalNr,
                endUserIp = userIp
            });
            content.Headers.ContentType = jsonContentHeader;
            HttpResponseMessage response = await httpClient.PostAsync("auth", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BankIdSignResponse>();
            }

            return await ParseErrorAsync(response);
        }

        private async Task<BankIdError> ParseErrorAsync(HttpResponseMessage response)
        {
            var error = await response.Content.ReadFromJsonAsync<BankIdError>();
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
                _ => throw new BankIdException("An unknown error was returned from server.")
            };
            
            return error with { MessageCode = messageCode };
        }

        protected abstract bool ValidateServerCertificate(HttpRequestMessage requestMessage, X509Certificate2 cert, X509Chain chain, SslPolicyErrors errors);

    }
}