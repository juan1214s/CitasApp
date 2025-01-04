using Microsoft.AspNetCore.Mvc;
using CitasApp.Dto.Doctor;
using CitasApp.Services.Doctor;
using System.Threading.Tasks;

namespace CitasApp.Controllers.Doctor
{
    [ApiController]
    [Route("JMSCITAS/doctor")]
    public class UpdateDoctorController : ControllerBase
    {
        private readonly UpdateDoctorService _updateDoctorService;

        public UpdateDoctorController(UpdateDoctorService updateDoctorService)
        {
            _updateDoctorService = updateDoctorService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                return BadRequest("Los datos del doctor no pueden estar vacíos.");
            }

            try
            {
                var result = await _updateDoctorService.UpdateDoctor(id, doctorDto);

                if (result)
                {
                    return Ok("El perfil del médico ha sido actualizado exitosamente.");
                }

                return NotFound("El perfil del médico no se encontró.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al actualizar el perfil del médico: {ex.Message}");
            }
        }
    }
}
