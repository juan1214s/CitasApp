using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.SheduleProgramming;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Doctor
{
    public class DoctorEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(80)]
        public string Specialty { get; set; }

        [StringLength(100)]
        public string LicenseNumber { get; set; }

        [StringLength(8)]
        public string Office { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UsersEntity User { get; set; }

        // Relación uno a muchos: Un médico puede tener muchas reservas
        public ICollection<BookingEntity> Bookings { get; set; }

        // Relación uno a muchos: Un médico puede tener muchas programaciones de horarios
        public ICollection<ScheduleProgrammingEntity> ScheduleProgrammings { get; set; }
    }
}
