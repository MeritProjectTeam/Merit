using System;
using System.Collections.Generic;
using System.Text;
using Merit.MeritService;

namespace Merit.MeritService
{
    public interface IMeritService
    {
        void SaveMerit(NewMerit merit);
        void SaveMeritBusiness(NewMeritBusiness bMerit);
        List<NewMerit> ReadMerit();

    }
}
