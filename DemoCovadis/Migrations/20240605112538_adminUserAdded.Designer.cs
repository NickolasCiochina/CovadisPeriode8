﻿//// <auto-generated />
//using System;
//using DemoCovadis.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//#nullable disable

//namespace DemoCovadis.Migrations
//{
//    [DbContext(typeof(LeenAutoDbContext))]
//    [Migration("20240605112538_adminUserAdded")]
//    partial class adminUserAdded
//    {
//        /// <inheritdoc />
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

//            modelBuilder.Entity("DemoCovadis.Models.Auto", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int?>("ChauffeurId")
//                        .HasColumnType("INTEGER");

//                    b.Property<double>("KilometersStand")
//                        .HasColumnType("REAL");

//                    b.Property<string>("Merk")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Opmerkingen")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.HasIndex("ChauffeurId");

//                    b.ToTable("Auto");
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Chauffeur", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("BeginAdres")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("EindAdres")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Naam")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("TelefoonNummer")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.ToTable("Chauffeur");
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Reservering", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<int>("AutoId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int>("ChauffeurId")
//                        .HasColumnType("INTEGER");

//                    b.Property<DateTime>("Datum")
//                        .HasColumnType("TEXT");

//                    b.Property<string>("EindAdres")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("StartAdres")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.HasIndex("AutoId");

//                    b.HasIndex("ChauffeurId");

//                    b.ToTable("Reservering");
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Role", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.ToTable("Role");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            Name = "Admin"
//                        },
//                        new
//                        {
//                            Id = 2,
//                            Name = "User"
//                        });
//                });

//            modelBuilder.Entity("DemoCovadis.Models.User", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("INTEGER");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.Property<string>("Password")
//                        .IsRequired()
//                        .HasColumnType("TEXT");

//                    b.HasKey("Id");

//                    b.ToTable("User");

//                    b.HasData(
//                        new
//                        {
//                            Id = 1,
//                            Email = "admin@example.com",
//                            Name = "Admin",
//                            Password = "AdminPassword"
//                        },
//                        new
//                        {
//                            Id = 2,
//                            Email = "user@example.com",
//                            Name = "User",
//                            Password = "UserPassword"
//                        });
//                });

//            modelBuilder.Entity("RoleUser", b =>
//                {
//                    b.Property<int>("RolesId")
//                        .HasColumnType("INTEGER");

//                    b.Property<int>("UsersId")
//                        .HasColumnType("INTEGER");

//                    b.HasKey("RolesId", "UsersId");

//                    b.HasIndex("UsersId");

//                    b.ToTable("RoleUser");
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Auto", b =>
//                {
//                    b.HasOne("DemoCovadis.Models.Chauffeur", "Chauffeur")
//                        .WithMany("Autos")
//                        .HasForeignKey("ChauffeurId");

//                    b.Navigation("Chauffeur");
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Reservering", b =>
//                {
//                    b.HasOne("DemoCovadis.Models.Auto", "Auto")
//                        .WithMany()
//                        .HasForeignKey("AutoId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("DemoCovadis.Models.Chauffeur", "Chauffeur")
//                        .WithMany()
//                        .HasForeignKey("ChauffeurId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("Auto");

//                    b.Navigation("Chauffeur");
//                });

//            modelBuilder.Entity("RoleUser", b =>
//                {
//                    b.HasOne("DemoCovadis.Models.Role", null)
//                        .WithMany()
//                        .HasForeignKey("RolesId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("DemoCovadis.Models.User", null)
//                        .WithMany()
//                        .HasForeignKey("UsersId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();
//                });

//            modelBuilder.Entity("DemoCovadis.Models.Chauffeur", b =>
//                {
//                    b.Navigation("Autos");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
