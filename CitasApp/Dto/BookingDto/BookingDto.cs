using CitasApp.Entityes.SheduleProgramming;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.BookingDto
{
    public class BookingDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre del usuario para pedir la cita.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Es obligatorio el horario de la cita.")]
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre del medico.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio especificar la hora de la cita.")]
        public TimeSpan AppointmentTime { get; set; }

    }
}
