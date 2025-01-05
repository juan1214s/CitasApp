using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.UserDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "La cédula o identificación es obligatoria.")]
        [Range(10000, int.MaxValue, ErrorMessage = "La identificación debe tener al menos 5 dígitos.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida para continuar.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe proporcionar una dirección de correo válida.")]
        public required string Email { get; set; }



        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Debe proporcionar un número de teléfono válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres.")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [RegularExpression("Doctor|Paciente", ErrorMessage = "El rol debe ser 'Doctor' o 'Paciente'.")]
        public required string Role { get; set; }
    }
}
