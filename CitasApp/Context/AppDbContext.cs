using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.Location;
using CitasApp.Entityes.Shedule;
using CitasApp.Entityes.Users;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        //importo las tabla para q el orm las cree

        public DbSet<AppointmentsAvailable> Bookings { get; set; }

        public DbSet<DoctorEntity> Doctor { get; set; }

        public DbSet<ScheduleEntity> schedule { get; set; }

        public DbSet<UsersEntity> User { get; set; }

        public DbSet<LocationEntity> Location { get; set; }

    }
}
