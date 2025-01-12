using CitasApp.Context;
using CitasApp.Services.Exceptions;

namespace CitasApp.Services.Doctor
{
    public class DeleteDoctorService
    {
        public readonly AppDbContext _context;
        public readonly ILogger<DeleteDoctorService> _logger;

        public DeleteDoctorService(AppDbContext context, ILogger<DeleteDoctorService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            if (id < 0)
            {
                _logger.LogError($"Se esta intentado eliminar un Doctor sin un ID valido: {id}");
                throw new ArgumentException("El ID del usuario debe de ser valido.");
            }

            try
            {
                var deleteDoctor = await _context.Doctor.FindAsync(id);

                if (deleteDoctor == null)
                {
                    _logger.LogError("El medico que intentas eliminar no existe.");
                    throw new ResourceNotFoundException("No se encontro el medico.");
                }

                _context.Doctor.Remove(deleteDoctor);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Se elimino correctamente el Doctor.");

                return true;
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar eliminar un medico: {ex.ToString()}");
                return false;
            }
        }
    }
}
