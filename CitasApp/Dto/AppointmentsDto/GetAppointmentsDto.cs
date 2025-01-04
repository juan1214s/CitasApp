using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.AppointmentsDto
{
    public class GetAppointmentsDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string State { get; set; } 
    }
}
