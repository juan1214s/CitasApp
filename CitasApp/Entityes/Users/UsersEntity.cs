using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.Location;
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
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public required string Email { get; set; }
         
        [Required]
        [StringLength(100)]
        public required string Password { get; set; }

        [StringLength(15)]
        public required string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public required string Role { get; set; }

        [Required]
        public int LocationId { get; set; }

        // Relación uno a uno: Un usuario puede ser un doctor
        public DoctorEntity? Doctor { get; set; }

        //aca agrego el id de la sede a la q pertenece el usuario
        [ForeignKey("LocationId")]
        public LocationEntity Location { get; set; }

        // Relación uno a muchos: Un usuario puede tener varias reservas
        public ICollection<AppointmentsAvailable> Appointment { get; set; } = new List<AppointmentsAvailable>();
    }
}
