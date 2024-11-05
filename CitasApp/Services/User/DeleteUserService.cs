using CitasApp.Context;

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
                return false;
            }

            try
            {
                var deleteUser = await _context.User.FindAsync(id);

                if (deleteUser == null)
                {
                    return false;
                }

                _context.User.Remove(deleteUser);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error al intentar eliminar el usuario: {ex.ToString()}");
                return false;
            }
        }
    }
}
