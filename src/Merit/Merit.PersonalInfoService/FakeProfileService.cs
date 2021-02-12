using Merit.MeritService;
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
        List<NewMerit> meritList = new List<NewMerit>();

        public FakeProfileService()
        {
            meritList.Add(new NewMerit("lastbilschaufför", "stora bilar", "det var kul", "100 år"));
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
                    Merits = meritList 
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
                    PhoneNumber = "222-2222222"
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
        public void EditPerson(Person person) // not working
        {
            var existingPerson = people
                .FirstOrDefault(people => people.Id == person.Id);
            if (existingPerson!=null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
            }
        }
    }
}

