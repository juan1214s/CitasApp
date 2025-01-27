using CitasApp.Dto.UserDto;
using CitasApp.Exceptions;
using CitasApp.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers.User
{
    [ApiController]
    [Route("JMSCITAS/usuarios")]
    public class GetUserByIdController : ControllerBase
    {
        private readonly GetUserByIdService _userService;
        private readonly ILogger<GetUserByIdController> _logger;

        public GetUserByIdController(GetUserByIdService userService, ILogger<GetUserByIdController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var userDto = await _userService.GetUserById(id);
                return Ok(userDto);
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning("No se encontro ningun usuario con el ID proporcionado.");
                return NotFound(new { message = "No se encontro el usuario." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error interno al obtener el usuario: {ex.ToString()}");
                return StatusCode(500, new { error = "Error interno al obtener el usuario." });
            }
        }
    }
}
