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
            if (id <= 0)
            {
                return BadRequest(new { error = "Debes ingresar un ID válido." });
            }

            try
            {
                var result = await _deleteUser.DeleteUser(id);

                if (!result)
                {
                    return NotFound(new { error = "Usuario no encontrado." });
                }
                else
                {
                    return Ok(new { mensaje = "Se eliminó correctamente el usuario." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al intentar eliminar el usuario: {ex}");
                return StatusCode(500, new { error = "Error interno al intentar eliminar un usuario." });
            }
        }
    }
}
