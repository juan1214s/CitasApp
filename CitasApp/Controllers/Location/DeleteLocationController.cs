using CitasApp.Exceptions;
using CitasApp.Services.Locations;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers.Location
{
    [ApiController]
    [Route("JMSCITAS/location")]
    public class DeleteLocationController  : ControllerBase
    {
        private readonly DeleteLocationService _deleteLocationService;
        private readonly ILogger<DeleteLocationController> _logger;

        public DeleteLocationController(DeleteLocationService deleteLocationService, ILogger<DeleteLocationController> logger)
        {
            _deleteLocationService = deleteLocationService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var result = await _deleteLocationService.DeleteLocation(id);
                return Ok(new { message = "Se elimino correctamente la ubicaciòn." });
            }
            catch (ResourceNotFoundException ex )
            {
                _logger.LogWarning($"No se encontró la ubicaciòn: {ex.Message}");
                return NotFound(new { message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error interno al intentar eliminar la ubicacion: {ex}");
                return StatusCode(500, new { error = "Error interno al intentar eliminar la ubicaciòn." });
            }
        }

    }
}
