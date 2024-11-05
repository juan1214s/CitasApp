using CitasApp.Dto.UserDto;
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

                if (userDto == null)
                {
                    _logger.LogInformation("Usuario no encontrado.");
                    return NotFound(new {error = "Usuario no encontrado."});
                }

                return Ok(userDto);
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
