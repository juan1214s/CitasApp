using CitasApp.Services.Locations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitasApp.Dto.LocationDto;
using CitasApp.Exceptions;

namespace CitasApp.Controllers.Location
{
    [ApiController]
    [Route("JMSCITAS/location")]
    public class GetLocationsController : ControllerBase
    {
        private readonly GetLocationsService _getLocationsService;
        private readonly ILogger<GetLocationsController> _logger;

        public GetLocationsController(GetLocationsService getLocationsService, ILogger<GetLocationsController> logger)
        {
            _getLocationsService = getLocationsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _getLocationsService.GetLocations();
                return Ok(locations); 
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(new { message = ex.Message }); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las ubicaciones: {ex.Message}");
                return StatusCode(500, new { error = "Error interno al obtener las ubicaciones." });  
            }
        }
    }
}
