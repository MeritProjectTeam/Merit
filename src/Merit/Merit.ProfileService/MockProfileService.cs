using System;

namespace Merit.ProfileService
{
    public class MockProfileService : IProfileService
    {
        private Person currentPerson;

        public void SavePerson(int Id, string firstName, string lastName, DateTime dateOfBirth)
        {
            currentPerson = new(firstName, lastName, dateOfBirth);
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
    }
}
