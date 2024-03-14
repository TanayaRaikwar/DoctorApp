﻿// <auto-generated />
using System;
using DoctorApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorApp.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorApp.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorApp.Models.DoctorSpecialization", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("SpecializationDate")
                        .HasColumnType("date");

                    b.HasKey("DoctorId", "SpecializationCode");

                    b.HasIndex("SpecializationCode");

                    b.ToTable("DoctorSpecializations");
                });

            modelBuilder.Entity("DoctorApp.Models.Specialization", b =>
                {
                    b.Property<string>("SpecializationCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SpecializationName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("SpecializationCode");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("DoctorApp.Models.Surgery", b =>
                {
                    b.Property<int>("SurgeryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SurgeryCategory")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<DateOnly>("SurgeryDate")
                        .HasColumnType("date");

                    b.HasKey("SurgeryId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Surgeries");
                });

            modelBuilder.Entity("DoctorApp.Models.DoctorSpecialization", b =>
                {
                    b.HasOne("DoctorApp.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorApp.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("DoctorApp.Models.Surgery", b =>
                {
                    b.HasOne("DoctorApp.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
