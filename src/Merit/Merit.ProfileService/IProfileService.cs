using System;

namespace Merit.ProfileService
{
    public interface IProfileService
    {
        void SaveAddress(string street, string zipcode, string city);
        void SaveContactInfo(string email, string phone);
        void SavePerson(string firstName, string lastName, DateTime dateOfBirth);
        int GetAgeFor(string firstName, string lastName);
        Person Get(int id);
    }
}