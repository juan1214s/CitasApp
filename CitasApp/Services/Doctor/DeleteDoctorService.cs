using CitasApp.Context;

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

        public async Task<bool> DeleDoctor(int id)
        {
            if (id < 0)
            {
                _logger.LogError("El parametro que se intenta pasar al eliminar el medico no es valido.");
                return false;
            }

            try
            {
                var deleteDoctor = await _context.Doctor.FindAsync(id);

                if (deleteDoctor == null)
                {
                    _logger.LogError("El medico que intentas eliminar no existe.");
                    throw new InvalidOperationException("El medico que intentas eliminar no existe.");
                }

                _context.Doctor.Remove(deleteDoctor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al intentar eliminar un medico: {ex.ToString()}");
                return false;
            }
        }
    }
}
