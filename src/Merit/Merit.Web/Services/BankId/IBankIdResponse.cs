using System.Text.Json.Serialization;

namespace Merit.Web.Services.BankId
{
    public interface IBankIdResponse
    {
        [JsonIgnore]
        public MessageCode MessageCode => MessageCode.None;
    }
}