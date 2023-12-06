﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using appmed.Infrastructure.Context;

#nullable disable

namespace appmed.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231206192530_CreateTable_Employee")]
    partial class CreateTable_Employee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("appmed.Domain.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatienteId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SpecialityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("appmed.Domain.Entities.DoctorSpeciality", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("integer");

                    b.HasKey("DoctorId", "SpecialityId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("DoctorSpecialities");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Patiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patientes");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Consultation", b =>
                {
                    b.HasOne("appmed.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Consultations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("appmed.Domain.Entities.Patiente", "Patiente")
                        .WithMany("Consultations")
                        .HasForeignKey("PatienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patiente");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("appmed.Domain.Entities.Speciality", null)
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialityId");
                });

            modelBuilder.Entity("appmed.Domain.Entities.DoctorSpeciality", b =>
                {
                    b.HasOne("appmed.Domain.Entities.Doctor", "Doctor")
                        .WithMany("DoctorSpecialities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("appmed.Domain.Entities.Speciality", "Speciality")
                        .WithMany("DoctorSpecialities")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("DoctorSpecialities");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Patiente", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("appmed.Domain.Entities.Speciality", b =>
                {
                    b.Navigation("DoctorSpecialities");

                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
