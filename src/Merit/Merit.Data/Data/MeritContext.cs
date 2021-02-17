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

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyMerit> CompanyMerits { get; set; }
        public DbSet<PersonalMerit> PersonalMerits { get; set; }
        public DbSet<PersonalInfo> Persons { get; set; }
    }
}
