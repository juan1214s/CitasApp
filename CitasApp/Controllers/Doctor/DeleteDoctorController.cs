using CitasApp.Exceptions;
using CitasApp.Services.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers.Doctor
{
    [ApiController]
    [Route("JMSCITAS/medico")]
    public class DeleteDoctorController : ControllerBase
    {
        private readonly DeleteDoctorService _deleteDoctorService;
        private readonly ILogger<DeleteDoctorController> _logger;

        public DeleteDoctorController(DeleteDoctorService deleteDoctorService, ILogger<DeleteDoctorController> logger)
        {
            _deleteDoctorService = deleteDoctorService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                var result = await _deleteDoctorService.DeleteDoctor(id);
                return Ok(new { message = "Se elimino correctamente el Doctor." });
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning($"No se encontró el doctor: {ex.Message}");
                return NotFound(new { message = "El Doctor no fue encontrado. " });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Error en la validación: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar eliminar el médico: {ex.ToString()}");
                return StatusCode(500, new { error = "Hubo un error interno al intentar eliminar el médico." });
            }
        }
    }
}
