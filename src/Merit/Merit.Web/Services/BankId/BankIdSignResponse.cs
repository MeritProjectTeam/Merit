using System;

namespace Merit.Web.Services.BankId
{
    public record BankIdSignResponse : IBankIdResponse
    {
        public Guid OrderRef { get; init; }
        public Guid AutoStartToken { get; init; }
        public Guid QrStartToken { get; init; }
        public Guid QrStartSecret { get; init; }

        public MessageCode MessageCode => MessageCode.None;
    }
}