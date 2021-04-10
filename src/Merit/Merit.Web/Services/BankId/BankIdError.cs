using System.Net;
using System.Text.Json.Serialization;

namespace Merit.Web.Services.BankId
{
    public record BankIdError : IBankIdResponse
    {
        [JsonIgnore]
        public MessageCode MessageCode { get; init; }
        public string ErrorCode { get; init; }
        public string Description { get; init; }
    }
}