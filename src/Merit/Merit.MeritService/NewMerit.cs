﻿using System;

namespace Merit.MeritService
{
    public class NewMerit
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        public NewMerit(string category, string subCategory, string description, string duration)
        {
            Category = category;
            SubCategory = subCategory;
            Description = description;
            Duration = duration;
        }

        public NewMerit()
        {

        }
    }
}
