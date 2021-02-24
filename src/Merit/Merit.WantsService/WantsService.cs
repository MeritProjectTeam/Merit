using System;



namespace Merit.WantsService
{
    public class WantsService : IWantsService
    {
        public void CreateCompanyWant(string want)
        {
            using (var db = new MeritContext());
        }

        public void CreatePersonalWant(string want)
        {
            throw new NotImplementedException();
        }
    }
}
