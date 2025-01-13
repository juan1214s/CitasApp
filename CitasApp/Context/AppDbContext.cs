using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Location;
using CitasApp.Entityes.Users;
using CitasApp.Entityes.Doctor;
using Microsoft.EntityFrameworkCore;
using CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment;
using CitasApp.Entityes.ScheduleDAppointments;
using CitasApp.Entityes.Shedule;

namespace CitasApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DoctorEntity> Doctor { get; set; }
        public DbSet<LocationEntity> Location { get; set; }
        public DbSet<UsersEntity> User { get; set; }
        public DbSet<AppointmentsAvailableEntity> Appointment { get; set; }
        public DbSet<ScheduledAppointmentsEntity> ScheduledAppointments { get; set; }
        public DbSet<ScheduleEntity> Schedule { get; set; }

    }
}
