using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merit.Data.Models;

namespace Merit.Data.Data
{
    public class MeritContext : DbContext
    {
        readonly string connectionString = string.Empty;

        public MeritContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("ConnectionString");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<CompanyMerit> CompanyMerits { get; set; }
        public DbSet<PersonalMerit> PersonalMerits { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<PersonalUser> PersonalUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public DbSet<CompanyWants> CompanyWants { get; set; }
        public DbSet<PersonalWants> PersonalWants { get; set; }
        public DbSet<CompanyImage> CompanyImages { get; set; }
        public DbSet<PersonalImage> PersonalImages { get; set; }
    }
}
