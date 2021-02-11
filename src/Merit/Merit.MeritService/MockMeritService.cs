using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Merit.MeritService;

namespace Merit.MeritService
{
    public class MockMeritService : IMeritService
    {
                
        public void SaveMerit(NewMerit merit)
        {
            using StreamWriter sw = new StreamWriter("wwwroot/DataFile/MeritMockar.csv", true);
            sw.WriteLine($"{merit.Category},{merit.SubCategory},{merit.Description},{merit.Duration}");
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
    }
}
