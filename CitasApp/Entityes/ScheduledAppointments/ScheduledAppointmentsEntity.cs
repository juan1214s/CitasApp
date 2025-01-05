using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.ScheduleDAppointments
{
    public class ScheduledAppointmentsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppointmentsAvailableId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("AppointmentsAvailableId")]
        public required AppointmentsAvailableEntity AppointmentsAvailableEntity { get; set; }

        [ForeignKey("UserId")]
        public required UsersEntity User { get; set; }
    }
}

