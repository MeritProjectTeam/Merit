using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Merit.MeritService;

namespace Merit.MeritService
{
    public class MeritService : IMeritService
    {
        public void SaveMerit(NewMerit merit)
        {
            //behöver denna också en metod som plockar in vem som är inloggad?

            using (var db = new MeritContext())
            {
                db.PersonalMerits.Add(merit);
                db.SaveChanges();
            }
        }
        public List<NewMerit> ReadMerit()
        {
            List<NewMerit> listOfMerits = new List<NewMerit>();
            string[] textFileLines = File.ReadAllLines("wwwroot/DataFile/MeritMockar.csv");
            foreach (var line in textFileLines)
	        {
                string[] tempfile = line.Split(',');
                NewMerit merit = new NewMerit(tempfile[0], tempfile[1], tempfile[2], tempfile[3]);
                listOfMerits.Add(merit);
	        }
            return listOfMerits;
        }
        public void SaveMeritBusiness(NewMeritBusiness bMerit)
        {
            using StreamWriter sw = new StreamWriter("wwwroot/DataFile/MeritBusinessMockar.csv", true);
            sw.WriteLine($"{bMerit.Category},{bMerit.SubCategory},{bMerit.Description}");
        }
    }
}
