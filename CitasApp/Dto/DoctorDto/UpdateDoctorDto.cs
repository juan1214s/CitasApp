using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.Doctor
{
    public class UpdateDoctorDto
    {
        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public required string Specialty { get; set; }

        [Required(ErrorMessage = "El numero de la licencia es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public required string LicenseNumber { get; set; }

        [Required(ErrorMessage = "Debes ingresar el numero de la oficina.")]
        public required string Office { get; set; }

        [Required(ErrorMessage = "El Id de la sede es requerido para hacer la relacion.")]
        public required int LocationId { get; set; }
    }
}
