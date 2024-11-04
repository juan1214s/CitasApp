using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.SheduleProgramming;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Entityes.Doctor
{
    public class DoctorEntity
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string Specialty { get; set; }

        [StringLength(100)]
        public string LicenseNumber { get; set; }

        [StringLength(8)]
        public string Office { get; set; }

        public int UserId { get; set; }

        //relacion uno a uno
        public UsersEntity User { get; set; }

        //citas relacion uno a muchos
        public ICollection<BookingEntity> bookings { get; set; }

        public ICollection<ScheduleProgrammingEntity> scheduleProgrammings { get; set; }
    }
}
