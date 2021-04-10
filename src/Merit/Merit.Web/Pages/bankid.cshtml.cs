using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Merit.Web.Services.BankId;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;

namespace Merit.Web.Pages
{
    public class BankIdModel : PageModel
    {
        private static readonly QRCodeGenerator qrGenerator = new();
        public BankIdData Data { get; set; }
        public async Task OnGetAsync(BankIdTestService bankId)
        {
            Data = new();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await bankId.AuthorizeAsync(null, ip);
            Data.StatusMessage = BankIdService.GetUserMessage(result.MessageCode);

            if (result is AuthResponse authResponse)
            {
                string qrString = SvgQRCodeHelper.GetQRCode($@"bankid:///?autostarttoken={authResponse.AutoStartToken}",
                                                        5,
                                                        "#000000",
                                                        "#FFFFFF",
                                                        QRCodeGenerator.ECCLevel.L);
                Data.QrCode = new HtmlString(qrString);
            }
        }

        public class BankIdData
        {
            public string StatusMessage { get; set; }
            public HtmlString QrCode { get; set; }
        }
    }
}
