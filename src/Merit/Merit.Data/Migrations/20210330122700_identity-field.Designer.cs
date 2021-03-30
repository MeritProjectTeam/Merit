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
    [Migration("20210330122700_identity-field")]
    partial class identityfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Merit.Data.Models.CompanyImage", b =>
                {
                    b.Property<Guid>("CompanyImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CompanyUserId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyImageId");

                    b.HasIndex("CompanyUserId")
                        .IsUnique();

                    b.ToTable("CompanyImages");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyInfo", b =>
                {
                    b.Property<int>("CompanyInfoId")
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

                    b.HasKey("CompanyInfoId");

                    b.HasIndex("CompanyUserID")
                        .IsUnique();

                    b.ToTable("CompanyInfo");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyMerit", b =>
                {
                    b.Property<int>("CompanyMeritId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyMeritId");

                    b.HasIndex("CompanyUserId");

                    b.ToTable("CompanyMerits");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyUser", b =>
                {
                    b.Property<int>("CompanyUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyUserId");

                    b.ToTable("CompanyUsers");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyWants", b =>
                {
                    b.Property<int>("CompanyWantsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Want")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyWantsId");

                    b.HasIndex("CompanyUserId");

                    b.ToTable("CompanyWants");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalImage", b =>
                {
                    b.Property<Guid>("PersonalImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalUserId")
                        .HasColumnType("int");

                    b.HasKey("PersonalImageId");

                    b.HasIndex("PersonalUserId")
                        .IsUnique();

                    b.ToTable("PersonalImages");
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

                    b.Property<int>("PersonalUserID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalInfoId");

                    b.HasIndex("PersonalUserID")
                        .IsUnique();

                    b.ToTable("PersonalInfo");
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

                    b.Property<int>("PersonalUserId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalMeritId");

                    b.HasIndex("PersonalUserId");

                    b.ToTable("PersonalMerits");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalUser", b =>
                {
                    b.Property<int>("PersonalUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalUserId");

                    b.ToTable("PersonalUsers");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalWants", b =>
                {
                    b.Property<int>("PersonalWantsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonalUserId")
                        .HasColumnType("int");

                    b.Property<string>("Want")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalWantsID");

                    b.HasIndex("PersonalUserId");

                    b.ToTable("PersonalWants");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyImage", b =>
                {
                    b.HasOne("Merit.Data.Models.CompanyUser", "CompanyUser")
                        .WithOne("CompanyImage")
                        .HasForeignKey("Merit.Data.Models.CompanyImage", "CompanyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyInfo", b =>
                {
                    b.HasOne("Merit.Data.Models.CompanyUser", "CompanyUser")
                        .WithOne("CompanyInfo")
                        .HasForeignKey("Merit.Data.Models.CompanyInfo", "CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyMerit", b =>
                {
                    b.HasOne("Merit.Data.Models.CompanyUser", "CompanyUser")
                        .WithMany("CompanyMerits")
                        .HasForeignKey("CompanyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyWants", b =>
                {
                    b.HasOne("Merit.Data.Models.CompanyUser", "CompanyUser")
                        .WithMany("CompanyWants")
                        .HasForeignKey("CompanyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalImage", b =>
                {
                    b.HasOne("Merit.Data.Models.PersonalUser", "PersonalUser")
                        .WithOne("PersonalImage")
                        .HasForeignKey("Merit.Data.Models.PersonalImage", "PersonalUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalUser");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalInfo", b =>
                {
                    b.HasOne("Merit.Data.Models.PersonalUser", "PersonalUser")
                        .WithOne("PersonalInfo")
                        .HasForeignKey("Merit.Data.Models.PersonalInfo", "PersonalUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalUser");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalMerit", b =>
                {
                    b.HasOne("Merit.Data.Models.PersonalUser", "PersonalUser")
                        .WithMany("PersonalMerits")
                        .HasForeignKey("PersonalUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalUser");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalWants", b =>
                {
                    b.HasOne("Merit.Data.Models.PersonalUser", "PersonalUser")
                        .WithMany("PersonalWants")
                        .HasForeignKey("PersonalUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalUser");
                });

            modelBuilder.Entity("Merit.Data.Models.CompanyUser", b =>
                {
                    b.Navigation("CompanyImage");

                    b.Navigation("CompanyInfo");

                    b.Navigation("CompanyMerits");

                    b.Navigation("CompanyWants");
                });

            modelBuilder.Entity("Merit.Data.Models.PersonalUser", b =>
                {
                    b.Navigation("PersonalImage");

                    b.Navigation("PersonalInfo");

                    b.Navigation("PersonalMerits");

                    b.Navigation("PersonalWants");
                });
#pragma warning restore 612, 618
        }
    }
}