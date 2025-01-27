using CitasApp.Exceptions;
using CitasApp.Services.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers.Doctor
{
    [Controller]
    [Route("JMSCITAS/doctor")]
    public class GetDoctorByIdController : ControllerBase
    {
        private readonly ILogger<GetDoctorByIdController> _logger;
        private readonly GetDoctorByIdService _doctorService;

        public GetDoctorByIdController(ILogger<GetDoctorByIdController> logger, GetDoctorByIdService doctorService)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            try
            {
                var doctorResult = await _doctorService.GetDoctor(id);
                return Ok(doctorResult);
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning("No se encontro ningun doctor con el ID proporcionado.");
                return NotFound(new { error = "No se encontro el doctor." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error interno al obtener el doctor: {ex.ToString()}");
                return StatusCode(500, new { error = "Error interno al obtener el doctor." });
            }
        }
    }
}
