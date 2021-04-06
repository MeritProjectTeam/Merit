using Merit.Data.Data;
using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.Data
{
    public class AccountRequest
    {
        public void AddAccount(PersonalUser user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan
            using (var db = new MeritContext())
            {
                db.Add(user);
                db.SaveChanges();

                try
                {
                    PersonalInfo info = new PersonalInfo();
                    info.PersonalUserId = user.PersonalUserId;
                    db.Add(info);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    db.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public void AddAccount(CompanyUser user)
        {
            //krypteringen sker på server-sidan, bör bytas till klient-sidan

            using (var db = new MeritContext())
            {

                db.Add(user);
                db.SaveChanges();

                try
                {
                    CompanyInfo info = new CompanyInfo();
                    info.CompanyUserId = user.CompanyUserId;
                    db.Add(info);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    db.Remove(user);
                    db.SaveChanges();
                }

            }
        }

        public PersonalUser GetPersonalUser(int id)
        {
            using (var db = new MeritContext())
                return db.PersonalUsers
                    .FirstOrDefault(p => p.PersonalUserId == id);
        }
        public CompanyUser GetCompanyUser(int id)
        {
            using (var db = new MeritContext())
                return db.CompanyUsers
                    .FirstOrDefault(p => p.CompanyUserId == id);
        }
    }

    public enum AccountCheck
    {
        NoUserExists = 0,
        MailExists,
        NameExists,
    }
}
