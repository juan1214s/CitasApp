﻿// <auto-generated />
using System;
using CitasApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250105022508_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment.AppointmentsAvailableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("CitasApp.Entityes.Doctor.DoctorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("CitasApp.Entityes.Location.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CitasApp.Entityes.ScheduleDAppointments.ScheduledAppointmentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentsAvailableId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentsAvailableId");

                    b.HasIndex("UserId");

                    b.ToTable("ScheduledAppointments");
                });

            modelBuilder.Entity("CitasApp.Entityes.Shedule.ScheduleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Hour")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("CitasApp.Entityes.Users.UsersEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment.AppointmentsAvailableEntity", b =>
                {
                    b.HasOne("CitasApp.Entityes.Doctor.DoctorEntity", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitasApp.Entityes.Shedule.ScheduleEntity", "Schedule")
                        .WithMany("appointmentsAvailables")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("CitasApp.Entityes.Doctor.DoctorEntity", b =>
                {
                    b.HasOne("CitasApp.Entityes.Location.LocationEntity", "Location")
                        .WithMany("Doctor")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitasApp.Entityes.Users.UsersEntity", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("CitasApp.Entityes.Doctor.DoctorEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CitasApp.Entityes.ScheduleDAppointments.ScheduledAppointmentsEntity", b =>
                {
                    b.HasOne("CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment.AppointmentsAvailableEntity", "AppointmentsAvailableEntity")
                        .WithMany("ScheduledAppointments")
                        .HasForeignKey("AppointmentsAvailableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitasApp.Entityes.Users.UsersEntity", "User")
                        .WithMany("ScheduledAppointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentsAvailableEntity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CitasApp.Entityes.Users.UsersEntity", b =>
                {
                    b.HasOne("CitasApp.Entityes.Location.LocationEntity", "Location")
                        .WithMany("Users")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment.AppointmentsAvailableEntity", b =>
                {
                    b.Navigation("ScheduledAppointments");
                });

            modelBuilder.Entity("CitasApp.Entityes.Doctor.DoctorEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("CitasApp.Entityes.Location.LocationEntity", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CitasApp.Entityes.Shedule.ScheduleEntity", b =>
                {
                    b.Navigation("appointmentsAvailables");
                });

            modelBuilder.Entity("CitasApp.Entityes.Users.UsersEntity", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("ScheduledAppointments");
                });
#pragma warning restore 612, 618
        }
    }
}
