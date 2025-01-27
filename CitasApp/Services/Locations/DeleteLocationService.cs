using CitasApp.Context;
using CitasApp.Exceptions;

namespace CitasApp.Services.Locations
{
    public class DeleteLocationService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DeleteLocationService> _logger;

        public DeleteLocationService(AppDbContext context, ILogger<DeleteLocationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteLocation(int id)
        {
            if (id < 0)
            {
                _logger.LogError($"El ID debe ser valido: {id}");
                throw new ArgumentException("El ID del usuario es invalido.");
            }

            try
            {
                var deleteLocation = await _context.Location.FindAsync(id);

                if (deleteLocation == null)
                {
                    _logger.LogWarning($"Ubicaciòn no encontrada: {id}.");
                    throw new ResourceNotFoundException("Ubicaciòn no encontrada.");
                }

                _context.Location.Remove(deleteLocation);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Se elimino correctamente la ubicaciòn.");

                return true;            }
            catch(Exception ex)
            {
                _logger.LogError($"Error interno al intentar borrar la ubicaciòn: {id}: {ex}");
                throw new Exception("Error interno al intentar borrar la ubicaciòn.");
            }
        }
    }
}
