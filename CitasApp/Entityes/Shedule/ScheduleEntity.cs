﻿using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Appointment.CitasApp.Entityes.Appointment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Shedule
{

    public class ScheduleEntity
    {
        [Key]
        public int Id { get; set; }

        [Range(typeof(TimeSpan), "06:00:00", "22:00:00", ErrorMessage = "La hora debe estar entre las 06:00 y las 22:00.")]
        public TimeSpan Hour { get; set; }

        public ICollection<AppointmentsAvailableEntity> appointmentsAvailables { get; set; }

    }
}
