using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.ScheduleDAppointments;
using CitasApp.Entityes.Shedule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Appointment
{
    //citas disponibles
    namespace CitasApp.Entityes.Appointment
    {
        public class AppointmentsAvailableEntity
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int ScheduleId { get; set; }

            [Required]
            public int DoctorId { get; set; }

            [Required]
            public DateTime AppointmentDate { get; set; }

            [Required, StringLength(50)]
            public required string State { get; set; }

            [ForeignKey("DoctorId")]
            public required DoctorEntity Doctor { get; set; }

            [ForeignKey("ScheduleId")]
            public required ScheduleEntity Schedule { get; set; }

            public ICollection<ScheduledAppointmentsEntity> ScheduledAppointments { get; set; } = new List<ScheduledAppointmentsEntity>();
        }
    }

}