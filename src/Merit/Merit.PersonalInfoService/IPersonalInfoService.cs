using Merit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merit.PersonalInfoService
{
    public interface IPersonalInfoService
    {
        PersonalInfo Get(int id);

    }
}
