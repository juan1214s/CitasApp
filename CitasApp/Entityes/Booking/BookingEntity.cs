using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.SheduleProgramming;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Appointment
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UsersEntity User { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public ScheduleProgrammingEntity Schedule { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public DoctorEntity Doctor { get; set; }

        // Campo para la hora específica de la cita
        [Required]
        public TimeSpan AppointmentTime { get; set; } // Hora específica dentro del rango del horario
    }
}
