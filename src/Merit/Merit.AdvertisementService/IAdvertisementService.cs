﻿using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.AdvertisementService
{
    public interface IAdvertisementService
    {
        public int SaveAdvertisement(CompanyAdvertisement companyAdvertisement);

        public void UpdateAdvertisement(CompanyAdvertisement companyAdvertisement);

        public void SaveVisibleMerit(VisibleMerit merit);

        public void SaveVisibleWant(VisibleWant want);

        //public int GetAdvertisementId(int userId);
    }
}
