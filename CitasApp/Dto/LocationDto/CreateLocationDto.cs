using System.ComponentModel.DataAnnotations;

namespace CitasApp.Dto.LocationDto
{
    public class CreateLocationDto
    {
        [Required(ErrorMessage = "Es necesario agregar la hubicacion de la sede.")]
        [StringLength(50, ErrorMessage = "No se puede ingresar mas de 50 caracteres.")]
        public string Location { get; set; }
    }
}
