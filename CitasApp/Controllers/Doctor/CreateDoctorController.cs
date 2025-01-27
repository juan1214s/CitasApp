using CitasApp.Dto.Doctor;
using CitasApp.Exceptions;
using CitasApp.Services.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CitasApp.Controllers.Doctor
{
    [ApiController]
    [Route("JMSCITAS/doctor")]
    public class CreateDoctorController : ControllerBase
    {
        private readonly CreateDoctorService _createDoctorService;
        private readonly ILogger<CreateDoctorController> _logger;

        public CreateDoctorController(CreateDoctorService createDoctorService, ILogger<CreateDoctorController> logger)
        {
            _createDoctorService = createDoctorService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] PostDoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                _logger.LogWarning("Se intentó crear el perfil del médico con datos incompletos.");
                return BadRequest(new { message = "Todos los campos son requeridos para crear el perfil del médico." });
            }

            try
            {
                var result = await _createDoctorService.CreateDoctor(doctorDto);

                if (result)
                {
                    _logger.LogInformation("Se creó correctamente el perfil del médico.");
                    return StatusCode(201, new { message = "Se creó correctamente el perfil del médico." });
                }
                else
                {
                    _logger.LogError("Ocurrió un error al intentar crear el perfil del médico.");
                    return BadRequest(new { message = "Ocurrió un error al intentar crear el perfil del médico." });
                }
            }
            catch (ResourceAlreadyExistsException ex)
            {
                // Captura la excepción personalizada para el número de licencia duplicado
                _logger.LogWarning($"Error de validación: {ex.Message}");
                return BadRequest(new { message = $"Ya hay un médico registrado con ese número de licencia: {ex.Message}" });
            }
            catch (AccessNotReSource ex)
            {
                // Captura la excepción personalizada para el caso en que el usuario no tiene el rol de doctor
                _logger.LogWarning($"Error de validación: {ex.Message}");
                return BadRequest(new { message = $"El usuario no tiene el rol de doctor: {ex.Message}" });
            }
            catch (ResourceNotFoundException ex)
            {
                // Captura la excepción personalizada para el caso en que no se encuentra el usuario
                _logger.LogWarning($"Error de validación: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (AppExceptions ex)
            {
                // Captura excepciones generales personalizadas (como AppExceptions)
                _logger.LogError($"Excepción personalizada: {ex.Message}");
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Excepción general para otros errores no capturados
                _logger.LogError($"Error interno al intentar crear el perfil del médico: {ex}");
                return StatusCode(500, new { error = "Error interno al intentar crear el perfil del médico." });
            }
        }
    }
}
