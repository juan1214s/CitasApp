using CitasApp.Context;
using CitasApp.Services.Exceptions;

namespace CitasApp.Services.User
{
    public class DeleteUserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DeleteUserService> _logger;

        public DeleteUserService(AppDbContext context, ILogger<DeleteUserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (id < 0)
            {
                _logger.LogError($"Intento eliminar con un ID invalido: {id} ");
                throw new ArgumentException("El ID del usuario debe de ser valido.");
            }

            try
            {
                var deleteUser = await _context.User.FindAsync(id);

                if (deleteUser == null)
                {
                    _logger.LogWarning($"Usuario no encontrado con el ID: {id}");
                    throw new ResourceNotFoundException("Usuario no encontrado.");
                }

                _context.User.Remove(deleteUser);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Usuario con ID {id} eliminado exitosamente.");

                return true;

            }
            catch (ResourceNotFoundException ex)
            {
                // Manejo de la excepción de recurso no encontrado
                _logger.LogWarning($"Error: {ex.Message}");
                throw; // Dejar que el controlador maneje esta excepción
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al intentar eliminar el usuario con ID {id}: {ex}");
                throw new Exception("Error interno al intentar eliminar el usuario.");
            }
        }
    }
}
