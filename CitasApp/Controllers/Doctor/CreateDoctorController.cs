using CitasApp.Dto.Doctor;
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
                    return Ok(new { message = "Se creó correctamente el perfil del médico." });
                }
                else
                {
                    _logger.LogError("Ocurrió un error al intentar crear el perfil del médico.");
                    return BadRequest(new { message = "Ocurrió un error al intentar crear el perfil del médico." });
                }
            }
            catch (InvalidOperationException ex)
            {
                // Excepción personalizada, por ejemplo: si el número de licencia ya existe
                _logger.LogWarning($"Error de validación: {ex.Message}");
                return BadRequest(new { message = $"Ya hay un medico registrado con ese numero de licencia: {ex.ToString()}"});
            }
            catch (Exception ex)
            {
                // Excepción general para otros errores
                _logger.LogError($"Error interno al intentar crear el perfil del médico: {ex}");
                return StatusCode(500, new { error = "Error interno al intentar crear el perfil del médico." });
            }
        }
    }
}
