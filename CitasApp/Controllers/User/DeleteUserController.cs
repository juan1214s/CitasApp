using CitasApp.Exceptions;
using CitasApp.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CitasApp.Controllers.User
{
    [ApiController]
    [Route("JMSCITAS/usuarios")]
    public class DeleteUserController : ControllerBase
    {
        private readonly DeleteUserService _deleteUser;
        private readonly ILogger<DeleteUserController> _logger;

        public DeleteUserController(DeleteUserService deleteUser, ILogger<DeleteUserController> logger)
        {
            _deleteUser = deleteUser;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _deleteUser.DeleteUser(id);
                return Ok(new { message = "Usuario eliminado exitosamente." });
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning($"No se encontró el usuario: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Error en la validación: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al intentar eliminar el usuario: {ex}");
                return StatusCode(500, new { error = "Error interno al intentar eliminar un usuario." });
            }
        }
    }
}
