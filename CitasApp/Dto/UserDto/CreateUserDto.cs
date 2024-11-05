using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.UserDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe proporcionar una dirección de correo válida.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 100 caracteres.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Debe proporcionar un número de teléfono válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres.")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [RegularExpression("Doctor|Paciente", ErrorMessage = "El rol debe ser 'Doctor' o 'Paciente'.")]
        public required string Role { get; set; }
    }
}
