using CitasApp.Dto.LocationDto;
using CitasApp.Exceptions;
using CitasApp.Services.Locations;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers.Location
{
    [ApiController]
    [Route("JMSCITAS/location")]
    public class CreateLocationController : Controller
    {
        public readonly CreateLocationService _createLocationService;
        public readonly ILogger<CreateLocationController> _logger;

        public CreateLocationController(CreateLocationService createLocationService, ILogger<CreateLocationController> logger)
        {
            _createLocationService = createLocationService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto createLocationDto)
        {
            if (createLocationDto == null)
            {
                _logger.LogWarning("Los datos necesarios para crear la ubicacion estan incompletos.");
                return BadRequest(new { Message = "Todos los campos son requeridos." });
            }
            try
            {
                var result = await _createLocationService.CreateLocation(createLocationDto);

                if (result)
                {
                    _logger.LogInformation("Se creo correctamente la ubicacion.");
                    return StatusCode(201, new { Message = "Se creo correctamente la ubicacion." });
                }
                else
                {
                    _logger.LogWarning("Ocurrio un error al intentar crear la ubicacion.");
                    return BadRequest(new { Message = "Ocurrio un error al intentar crear la ubicacion." });
                }
            }
            catch (AppExceptions ex)
            {
                // Captura excepciones generales personalizadas (como AppExceptions)
                _logger.LogError($"Excepción personalizada: {ex.Message}");
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error interno al intentar crear la ubicacion: {ex}");
                return StatusCode(500, new { Error = "Error interno al intentar crear la ubicacion" });
            }
        }
    }
}
