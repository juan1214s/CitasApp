using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Users
{
    public class UsersEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } 

        // Relación uno a uno: Un usuario puede ser un doctor
        public DoctorEntity? Doctor { get; set; }

        // Relación uno a muchos: Un usuario puede tener varias reservas
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}
