using CitasApp.Entityes.Doctor;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.ScheduleDto
{
    public class CreateScheduleProgrammingDto
    {
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "La hora de inicio de la jornada es obligatori.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de final de la jornada es obligatori.")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Debe indicar si el medico se encuentra activo o no.")]
        public bool State { get; set; }

        [Required(ErrorMessage = "Debes ingresar el nombre del medico para congigurar su horario.")]
        public int DoctorId { get; set; }

    }
}
