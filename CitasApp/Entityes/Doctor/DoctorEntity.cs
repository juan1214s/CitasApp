using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Location;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasApp.Entityes.Doctor
{
    public class DoctorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public required string Specialty { get; set; }

        [Required]
        [StringLength(100)]
        public required string LicenseNumber { get; set; }    

        [StringLength(8)]
        public required string Office { get; set; }

        // Relación muchos a uno: Un médico pertenece a una sola sede
        [Required]
        public int LocationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UsersEntity User { get; set; }

        // Relación uno a muchos: Un médico puede tener muchas reservas
        public ICollection<AppointmentsAvailable> Appointments { get; set; }

        [ForeignKey("LocationId")]
        public LocationEntity Location { get; set; }
    }
}
