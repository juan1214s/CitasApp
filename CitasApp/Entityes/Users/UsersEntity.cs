using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using System.ComponentModel.DataAnnotations;

namespace CitasApp.Entityes.Users
{
    public class UsersEntity
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Role { get; set; } 

        // Relación uno a uno (opcional): un usuario puede ser un doctor
        public DoctorEntity Doctor { get; set; }

        // Relación uno a muchos: un usuario puede tener varias reservas
        public ICollection<BookingEntity> Bookings { get; set; } // Reserva o citas
    }
}
