using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public class FakeProfileService : IPersonalInfoService
    {
        //private PersonalInfo currentPerson;
        //List<PersonalInfo> people;
        //List<NewMerit> meritList = new List<NewMerit>();

        //public FakeProfileService()
        //{
        //    meritList.Add(new NewMerit());
        //    people = new List<PersonalInfo>()
        //    {
        //        new PersonalInfo
        //        {
        //            PersonalInfoId = 1,
        //            FirstName = "Anna",
        //            LastName = "Annasson",
        //            DateOfBirth = DateTime.Parse("2001-01-01"),
        //            City = "Stockholm",
        //            ZipCode = "11111",
        //            Street = "Aväg1",
        //            PhoneNumber = "111-111111",
        //        },
        //          new PersonalInfo
        //        {
        //            PersonalInfoId = 2,
        //            FirstName = "Bertil",
        //            LastName = "Bertilsson",
        //            DateOfBirth = DateTime.Parse("2001-02-02"),
        //            City = "Stockholm",
        //            ZipCode = "222222",
        //            Street = "Bväg2",
        //            PhoneNumber = "222-2222222",
        //        }
        //    };
        //}
        //public void SavePerson(string firstName, string lastName, DateTime dateOfBirth)
        //{
        //    currentPerson = new PersonalInfo()
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        DateOfBirth = dateOfBirth,

        //    };
        //}
        //public PersonalInfo GetPerson()
        //{
        //    return currentPerson;
        //}
        //public PersonalInfo Get(int id)
        //{
        //    return people
        //        .FirstOrDefault(p => p.PersonalInfoId == id);
        //}
        public PersonalInfo Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

