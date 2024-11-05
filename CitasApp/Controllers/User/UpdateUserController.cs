using CitasApp.Dto.UserDto;
using CitasApp.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CitasApp.Controllers.User
{
    [ApiController]
    [Route("JMSCITAS/usuarios")]
    public class UpdateUserController : ControllerBase
    {
        private readonly UpdateUserService _updateUserService;
        private readonly ILogger<UpdateUserController> _logger;

        public UpdateUserController(UpdateUserService updateUserService, ILogger<UpdateUserController> logger)
        {
            _updateUserService = updateUserService;
            _logger = logger;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            if (userDto == null)
            {
                _logger.LogWarning("Los datos del usuario son nulos para la actualización del ID: {Id}", id);
                return BadRequest(new { error = "Los datos del usuario son necesarios para actualizar." });
            }

            try
            {
                var result = await _updateUserService.UpdateUser(id, userDto);

                if (result)
                {
                    _logger.LogInformation("Usuario con ID: {Id} actualizado con éxito.", id);
                    return Ok(new { message = "Usuario actualizado con éxito." });
                }
                else
                {
                    _logger.LogWarning("No se pudo actualizar el usuario con ID: {Id}.", id);
                    return BadRequest(new { error = "No se pudo actualizar el usuario." });
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning("Error al actualizar el usuario con ID: {Id} - {ErrorMessage}", id, ex.Message);
                return BadRequest(new { error = ex.Message }); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno al intentar actualizar el usuario con ID: {Id}.", id);
                return StatusCode(500, new { error = "Error interno al intentar actualizar el usuario." });
            }
        }
    }
}
