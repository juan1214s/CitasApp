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
            if (id < 0)
            {
                return BadRequest(new { error = "Debes ingresar un ID válido." });
            }

            try
            {
                var result = await _deleteDoctorService.DeleDoctor(id);

                if (result)  // Si la eliminación fue exitosa
                {
                    _logger.LogInformation($"El médico con ID {id} fue eliminado exitosamente.");
                    return Ok(new { message = "El médico fue eliminado exitosamente." });
                }
                else  // Si no se pudo eliminar
                {
                    _logger.LogError($"Hubo un error al intentar eliminar el médico con ID {id}.");
                    return BadRequest(new { message = "No se pudo eliminar al médico. Inténtalo nuevamente." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar eliminar el médico: {ex.ToString()}");
                return StatusCode(500, new { error = "Hubo un error interno al intentar eliminar el médico." });
            }
        }
    }
}
