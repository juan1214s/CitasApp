using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.Location;
using CitasApp.Entityes.ScheduleDAppointments;
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
        
        //Citas disponibles
        public DbSet<AppointmentsAvailableEntity> Appointment { get; set; }

        //Medicos
        public DbSet<DoctorEntity> Doctor { get; set; }

        //  Horario
        public DbSet<ScheduleEntity> schedule { get; set; }

        //Usuarios
        public DbSet<UsersEntity> User { get; set; }

        //Sedes
        public DbSet<LocationEntity> Location { get; set; }

        //Citas Agendadas
        public DbSet<ScheduledAppointmentsEntity> ScheduledAppointments { get; set; }

    }
}
