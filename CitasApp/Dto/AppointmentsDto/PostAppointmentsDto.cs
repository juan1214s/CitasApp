using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.BookingDto
{
    public class PostAppointmentsDto
    {

        [Required(ErrorMessage = "Es obligatorio la hora de la cita.")]
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "Es obligatorio la fecha de la cita.")]
        public int AppointmentDate { get; set; }

        [Required(ErrorMessage = "Es obligatorio el nombre del medico.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio el estado de la cita.")]
        public required string State { get; set; } 

    }
}
