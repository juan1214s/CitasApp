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

        //Impone un formato especifico
        [Required, StringLength(15)]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "El teléfono debe contener solo números y un signo '+' opcional.")]
        public string? Phone { get; set; }

        [RegularExpression("Doctor|Paciente", ErrorMessage = "El rol debe ser 'Doctor' o 'Paciente'.")]
        public string? Role { get; set; }
    }
}
