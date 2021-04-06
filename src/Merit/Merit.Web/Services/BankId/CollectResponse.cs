using System;
using System.Text.Json.Serialization;

namespace Merit.Web.Services.BankId
{
    public record CollectResponse : IBankIdResponse
    {
        public Guid OrderRef { get; init; }
        public string Status { get; init; }
        public string HintCode { get; init; }
        public Completiondata CompletionData { get; init; }

        [JsonIgnore]
        public MessageCode MessageCode { get; init; }

        public record Completiondata
        {
            public User User { get; init; }
            public Device Device { get; init; }
            public Cert Cert { get; init; }
            public string Signature { get; init; }
            public string OcspResponse { get; init; }
        }

        public record User
        {
            public string PersonalNumber { get; init; }
            public string Name { get; init; }
            public string GivenName { get; init; }
            public string Surname { get; init; }
        }

        public record Device
        {
            public string IpAddress { get; init; }
        }

        public record Cert
        {
            public string NotBefore { get; init; }
            public string NotAfter { get; init; }
        }
    }
}