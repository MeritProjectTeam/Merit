using System;
using System.Collections.Generic;
using System.Linq;

namespace Merit.ProfileService
{
    public class MockProfileService : IProfileService
    {
        private Person currentPerson;
        public void SavePerson(string firstName, string lastName, DateTime dateOfBirth)
        {
            currentPerson = new Person(firstName, lastName, dateOfBirth);
        }

        public void SaveAddress(string street, string zipcode, string city)
        {
            return;
        }
        public void SaveContactInfo(string email, string phone)
        {
            return;
        }
        public int GetAgeFor(string firstName, string lastName)
        {
            return 45;
        }
        public Person GetPerson()
        {
            return currentPerson;
        }
    }
}
