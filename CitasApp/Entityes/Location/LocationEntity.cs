using CitasApp.Entityes.Appointment;
using CitasApp.Entityes.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CitasApp.Entityes.Doctor;

namespace CitasApp.Entityes.Location
{

    public class LocationEntity
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(80)]
        public required string Location { get; set; }

        public ICollection<DoctorEntity> Doctor { get; set; }

        public ICollection<UsersEntity> Users { get; set; }

    }
}
