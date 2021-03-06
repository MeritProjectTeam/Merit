﻿using Merit.Data.Models;
using System;
using System.Collections.Generic;

namespace Merit.CompanyService
{
    public interface ICompanyService
    {
        public CompanyInfo Get(int id);
        public void SaveCompany(CompanyInfo company);
        public void EditCompanyInfo(CompanyInfo info);
        public List<CompanyInfo> GetAllCompany();
        public void DeleteCompanyInfo(int userId);
    }
}