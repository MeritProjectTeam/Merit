using System;

namespace Merit.Web.Services.BankId
{
    public record BankIdSignResponse : BankIdResponse
    {
        public Guid OrderRef { get; init; }
        public Guid AutoStartToken { get; init; }
        public Guid QrStartToken { get; init; }
        public Guid QrStartSecret { get; init; }
    }
}