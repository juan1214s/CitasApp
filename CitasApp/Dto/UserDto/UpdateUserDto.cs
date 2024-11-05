using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.UserDto
{
    public class UpdateUserDto
    {
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public  string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Debe proporcionar una dirección de correo válida.")]
        public  string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 100 caracteres.")]
        public  string? Password { get; set; }

        //[Phone(ErrorMessage = "Debe proporcionar un número de teléfono válido.")]
        //[StringLength(11, ErrorMessage = "El teléfono no puede tener más de 11 caracteres.")]
        public string? Phone { get; set; }

        [RegularExpression("Doctor|Paciente", ErrorMessage = "El rol debe ser 'Doctor' o 'Paciente'.")]
        public string? Role { get; set; }
    }
}
