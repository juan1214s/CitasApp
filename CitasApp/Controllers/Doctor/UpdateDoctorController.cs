using Microsoft.AspNetCore.Mvc;
using CitasApp.Dto.Doctor;
using CitasApp.Services.Doctor;
using System.Threading.Tasks;
using CitasApp.Services.Exceptions;

namespace CitasApp.Controllers.Doctor
{
    [ApiController]
    [Route("JMSCITAS/doctor")]
    public class UpdateDoctorController : ControllerBase
    {
        private readonly UpdateDoctorService _updateDoctorService;
        private readonly ILogger<UpdateDoctorController> _logger;

        public UpdateDoctorController(UpdateDoctorService updateDoctorService, ILogger<UpdateDoctorController> logger)
        {
            _updateDoctorService = updateDoctorService;
            _logger = logger;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto doctorDto)
        {
            try
            {
                var result = await _updateDoctorService.UpdateDoctor(id, doctorDto);
                _logger.LogInformation($"Doctor con ID {id} ha sido actualizado exitosamente.");
                return Ok("El perfil del médico ha sido actualizado exitosamente.");

            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(new { message = $"No se encontro el medico: {ex.Message}" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno al actualizar el perfil del médico: {ex.Message}");
            }
        }
    }
}
