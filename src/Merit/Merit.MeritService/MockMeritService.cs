using System;
using System.Collections.Generic;
using System.Text;

namespace Merit.MeritService
{
    public class MockMeritService : IMeritService
    {
        public void SaveMerit(NewMerit merit)
        {
            using StreamWriter sw = new StreamWriter(/src/Merit/Merit.MeritService/Datafile/MeritMockar.csv, true)
            {
                sw.WriteLine($"{merit.Category},{merit.SubCategory},{merit.Description},{merit.Duration}");
            }
        }
        public void ReadMerit()
        {
            string[] textFileLines = File.ReadAllLines(/src/Merit/Merit.MeritService/Datafile/MeritMockar.csv);
            foreach (var line in textFileLines)
	        {
                string[] tempfile = line.Split(',');
                NewMerit merit = new NewMerit(tempfile[0], tempfile[1], tempfile[2], tempfile[3]);
	        }
        }
    }
}
