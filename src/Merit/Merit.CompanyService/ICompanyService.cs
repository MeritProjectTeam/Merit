namespace Merit.CompanyService
{
    public interface ICompanyService
    {
        void SaveAdress(string street, string zipCode, string city);
        void SaveCompany(string companyName, string orgNumber);
        void SaveContactPerson(string contactName, string email, string phone);
    }
}