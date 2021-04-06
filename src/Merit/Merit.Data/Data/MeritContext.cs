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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisibleMerit>()
                .HasKey(v => new { v.CompanyAdvertisementId, v.CompanyMeritId });
            modelBuilder.Entity<VisibleMerit>()
                .HasOne(v => v.CompanyAdvertisement)
                .WithMany(c => c.VisibleMerits)
                .HasForeignKey(v => v.CompanyAdvertisementId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VisibleMerit>()
                .HasOne(v => v.CompanyMerit)
                .WithMany()
                .HasForeignKey(v => v.CompanyMeritId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VisibleWant>()
                .HasKey(v => new { v.CompanyAdvertisementId, v.CompanyWantsId});
            modelBuilder.Entity<VisibleWant>()
                .HasOne(v => v.CompanyAdvertisement)
                .WithMany(c => c.VisibleWants)
                .HasForeignKey(v => v.CompanyAdvertisementId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VisibleWant>()
                .HasOne(v => v.CompanyWants)
                .WithMany()
                .HasForeignKey(v => v.CompanyWantsId)
                .OnDelete(DeleteBehavior.NoAction);
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

        public DbSet<CompanyAdvertisement> CompanyAdvertisements { get; set; }

        public DbSet<VisibleWant> VisibleWants { get; set; }

        public DbSet<VisibleMerit> VisibleMerits { get; set; }

    }
}
