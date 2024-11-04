using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.SheduleProgramming;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Entityes.Appointment
{
    //horarios
    public class BookingEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UsersEntity User { get; set; }

        public int SheduleId { get; set; }

        public ScheduleProgrammingEntity Schedule { get; set; }

    }
}
