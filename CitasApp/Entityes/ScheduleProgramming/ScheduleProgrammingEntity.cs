using CitasApp.Entityes.Doctor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.SheduleProgramming
{
    // Aquí se almacenarán los horarios de las citas
    public class ScheduleProgrammingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } // Fecha de la programación

        [Required]
        public TimeSpan StartTime { get; set; } // Hora de inicio

        [Required]
        public TimeSpan EndTime { get; set; } // Hora de finalización

        [Required]
        public bool State { get; set; } // Indica si el horario está activo

        [Required]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public DoctorEntity Doctor { get; set; }
    }
}
