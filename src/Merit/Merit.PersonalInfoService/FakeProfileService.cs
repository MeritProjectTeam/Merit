using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public class FakeProfileService : IPersonalInfoService
    {
        private Person currentPerson;
        List<Person> people;
        List<Merit> meritList = new List<Merit>();

        public FakeProfileService()
        {
            meritList.Add(new Merit());
            people = new List<Person>()
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Anna",
                    LastName = "Annasson",
                    Email = "anna@mail.com",
                    DateOfBirth = DateTime.Parse("2001-01-01"),
                    City = "Stockholm",
                    ZipCode = "11111",
                    Street = "Aväg1",
                    PhoneNumber = "111-111111",
                    Merits = new List<Merit>()
                    {
                        new Merit()
                        {
                            Title = "Skola",
                            Category = "Utbildning"
                        },
                        new Merit()
                        {
                            Title = "Lumpen",
                            Category = "Militärtjänstgöring"
                        }
                    }
                },
                  new Person
                {
                    Id = 2,
                    FirstName = "Bertil",
                    LastName = "Bertilsson",
                    Email = "bertil@mail.com",
                    DateOfBirth = DateTime.Parse("2001-02-02"),
                    City = "Stockholm",
                    ZipCode = "222222",
                    Street = "Bväg2",
                    PhoneNumber = "222-2222222",
                    Merits = new List<Merit>()
                    {
                        new Merit()
                        {
                            Title = "Skola",
                            Category = "Utbildning"
                        },
                        new Merit()
                        {
                            Title = "Lumpen",
                            Category = "Militärtjänstgöring"
                        }
                    }
                }
            };
        }
        public void SavePerson(string firstName, string lastName, DateTime dateOfBirth)
        {
            currentPerson = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,

            };
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
        public List<Person> GetAll()
        {
            return people;
        }
        public Person EditPerson(Person editedPerson) // not working need async
        {
            var existingPerson = people
                .FirstOrDefault(p => p.Id == editedPerson.Id);
            if (existingPerson!=null)
            {
                existingPerson.FirstName = editedPerson.FirstName;
                existingPerson.LastName = editedPerson.LastName;
            }

            return existingPerson;
        }
    }
}

