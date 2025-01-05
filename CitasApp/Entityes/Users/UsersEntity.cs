using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.Location;
using CitasApp.Entityes.ScheduleDAppointments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Users
{
    public class UsersEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [Required, StringLength(100)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida para continuar.")]
        public DateTime BirthDate
        {
            get { return _birthDate.Date; } // Asegurando que solo se guarde la fecha
            set { _birthDate = value.Date; } // Asignando solo la fecha sin la hora
        }
        private DateTime _birthDate;

        [Required, StringLength(100), EmailAddress]
        public required string Email { get; set; }

        //Impone un formato especifico
        [Required, StringLength(15)]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "El teléfono debe contener solo números y un signo '+' opcional.")]
        public required string Phone { get; set; }

        [Required, StringLength(50)]
        public required string Role { get; set; }

        [Required]
        public int LocationId { get; set; }

        public DoctorEntity? Doctor { get; set; }

        [ForeignKey("LocationId")]
        public LocationEntity Location { get; set; }

        public ICollection<ScheduledAppointmentsEntity> ScheduledAppointments { get; set; } = new List<ScheduledAppointmentsEntity>();
    }
}

