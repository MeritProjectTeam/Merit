using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merit.Web.Services.BankId
{
    public class BankIdException : Exception
    {
        public bool RetryAllowed { get; }

        public BankIdException(string message, bool retryAllowed = false) : base(message)
        {
            RetryAllowed = retryAllowed;
        }
    }
}
