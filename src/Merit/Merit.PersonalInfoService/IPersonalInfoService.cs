using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public interface IPersonalInfoService
    {
        void SaveAddress(string street, string zipcode, string city);
        void SaveContactInfo(string email, string phone);
        void SavePerson(string firstName, string lastName, DateTime dateOfBirth);
        int GetAgeFor(string firstName, string lastName);
        Person Get(int id);
        public Person EditPerson(Person person);
        List<Person> GetAll();
    }
}
