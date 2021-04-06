using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Merit.Web.Services.BankId
{
    public class BankIdTestService : BankIdServiceBase
    {
        private const string certName = "FPTestcert3_20200618.p12";
        private const string certPass = "qwerty123";

        private static readonly Uri baseAddress = new(@"https://appapi2.test.bankid.com/rp/v5.1/");

        public string TestPersonalNumber => "196911039227";
        public string TestPersonPin => "147258";

        public BankIdTestService() : base(certName, certPass, baseAddress)
        {
        }

        protected override bool ValidateServerCertificate(HttpRequestMessage requestMessage, X509Certificate2 cert, X509Chain chain, SslPolicyErrors errors)
        {
            // Just accept the test-server certificate, ignoring errors.
            return true;
        }
    }

}
