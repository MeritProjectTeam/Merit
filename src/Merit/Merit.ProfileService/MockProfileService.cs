using System;
using System.Collections.Generic;
using System.Linq;

namespace Merit.ProfileService
{
    public class MockProfileService : IProfileService
    {
        private Person currentPerson;
        readonly List<Person> people;

        public MockProfileService()
        {
            people = new List<Person>()
            {
                new Person(1, "Anders", "Andersson", DateTime.Parse("2017-11-22"), "123@hotmail.com", "Testväg1", "Stockholm","11111", "111-1111111"),
                new Person(2, "Bertil", "Bertilsson", DateTime.Parse("2017-11-22"), "123@hotmail.com", "Testväg1", "Stockholm","11111", "111-1111111"),
                new Person(3, "Carl", "Carlsson", DateTime.Parse("2017-11-22"), "123@hotmail.com", "Testväg1", "Stockholm","11111", "111-1111111")
            };
        }

        public void SavePerson(string firstName, string lastName, DateTime dateOfBirth)
        {
            currentPerson = new Person(1, firstName, lastName, dateOfBirth, "hejsan@hotmail.com", "HejsanVägen 2", "Stockholm", "11111", "070-1234567");
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
        public Person Get(int id)
        {
            return people
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
