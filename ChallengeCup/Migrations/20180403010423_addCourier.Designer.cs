﻿// <auto-generated />
using ChallengeCup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ChallengeCup.Migrations
{
    [DbContext(typeof(ChallengeCupDbContext))]
    [Migration("20180403010423_addCourier")]
    partial class addCourier
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ChallengeCup.Models.Courier", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birthday")
                        .IsRequired();

                    b.Property<string>("Code");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Courier");
                });

            modelBuilder.Entity("ChallengeCup.Models.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Code");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("ChallengeCup.Models.History", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("DoctorId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("ChallengeCup.Models.Medicine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contraindication")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Indication")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("ChallengeCup.Models.MedicineOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourierId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("MedicineId")
                        .IsRequired();

                    b.Property<int>("State");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CourierId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicineOrder");
                });

            modelBuilder.Entity("ChallengeCup.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DoctorId")
                        .IsRequired();

                    b.Property<string>("Prescription");

                    b.Property<string>("ScoreId");

                    b.Property<int>("Status");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ScoreId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ChallengeCup.Models.Score", b =>
                {
                    b.Property<string>("ScoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Evaluate");

                    b.Property<int>("Mark");

                    b.HasKey("ScoreId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("ChallengeCup.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("Alone");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("FamilyPhoneNumber")
                        .HasMaxLength(11);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ChallengeCup.Models.MedicineOrder", b =>
                {
                    b.HasOne("ChallengeCup.Models.Courier", "Courier")
                        .WithMany()
                        .HasForeignKey("CourierId");

                    b.HasOne("ChallengeCup.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChallengeCup.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ChallengeCup.Models.Order", b =>
                {
                    b.HasOne("ChallengeCup.Models.Score", "Score")
                        .WithMany()
                        .HasForeignKey("ScoreId");
                });
#pragma warning restore 612, 618
        }
    }
}
