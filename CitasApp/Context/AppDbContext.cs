using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.SheduleProgramming;
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

        public DbSet<BookingEntity> Bookings { get; set; }

        public DbSet<DoctorEntity> Doctor { get; set; }

        public DbSet<ScheduleProgrammingEntity> Schedule  { get; set; }

        public DbSet<UsersEntity> User { get; set; }

    }
}
