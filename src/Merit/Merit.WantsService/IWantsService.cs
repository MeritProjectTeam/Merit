using System;
using System.Collections.Generic;
using System.Text;

namespace Merit.WantsService
{
    interface IWantsService
    {
        public void CreatePersonalWant(string want);
        public void CreateCompanyWant(string want);


    }
}
