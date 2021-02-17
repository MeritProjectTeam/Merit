﻿// <auto-generated />
using System;
using Merit.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Merit.Data.Migrations
{
    [DbContext(typeof(MeritContext))]
    [Migration("20210216140843_Version2")]
    partial class Version2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Merit.Data.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyUserID")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrgNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("CompanyUserID")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyMerit", b =>
                {
                    b.Property<int>("CompanyMeritId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyUserID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyMeritId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyUserID");

                    b.ToTable("CompanyMerits");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyUser", b =>
                {
                    b.Property<int>("CompanyUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyUserID");

                    b.ToTable("CompanyUsers");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalInfo", b =>
                {
                    b.Property<int>("PersonalInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalInfoId");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalMerit", b =>
                {
                    b.Property<int>("PersonalMeritId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PersonalMeritId");

                    b.HasIndex("UserID");

                    b.ToTable("PersonalMerits");
                });

            modelBuilder.Entity("Merit.Data.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Merit.Data.Models.Company", b =>
                {
                    b.HasOne("Merit.Data.Models.CompanyUser", "CompanyUser")
                        .WithOne("CompanyInfo")
                        .HasForeignKey("Merit.Data.Models.Company", "CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyMerit", b =>
                {
                    b.HasOne("Merit.Data.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merit.Data.Models.CompanyUser", null)
                        .WithMany("CompanyMerits")
                        .HasForeignKey("CompanyUserID");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalInfo", b =>
                {
                    b.HasOne("Merit.Data.Models.User", "user")
                        .WithOne("PersonalInfo")
                        .HasForeignKey("Merit.Data.Models.PersonalInfo", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalMerit", b =>
                {
                    b.HasOne("Merit.Data.Models.User", "User")
                        .WithMany("PersonalMerits")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyUser", b =>
                {
                    b.Navigation("CompanyInfo");

                    b.Navigation("CompanyMerits");
                });

            modelBuilder.Entity("Merit.Data.Models.User", b =>
                {
                    b.Navigation("PersonalInfo");

                    b.Navigation("PersonalMerits");
                });
#pragma warning restore 612, 618
        }
    }
}