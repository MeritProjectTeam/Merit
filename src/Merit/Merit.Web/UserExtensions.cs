using Merit.AccountService;
using Merit.Data.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Merit.Web
{
    public static class UserExtensions
    {
        public static AccountType GetAccountType(this IdentityUser identityUser)
        {
            using MeritContext db = new();
            if (db.PersonalUsers.Any(u => u.Identity == identityUser.Id))
            {
                return AccountType.Personal;
            }
            else if (db.CompanyUsers.Any(u => u.Identity == identityUser.Id))
            {
                return AccountType.Company;
            }
            throw new InvalidOperationException("No profile matches the current user.");
        }
    }
}