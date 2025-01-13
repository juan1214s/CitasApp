using CitasApp.Context;
using CitasApp.Dto.Doctor;
using CitasApp.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Services.Doctor
{
    public class GetDoctorByIdService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetDoctorByIdService> _logger;

        public GetDoctorByIdService(AppDbContext context, ILogger<GetDoctorByIdService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<GetDoctorDto> GetDoctor(int id)
        {
            if (id < 0)
            {
                _logger.LogWarning("Para obtener el doctor debes proporcionar un ID válido.");
                throw new ArgumentException("El valor que se proporcionó es inválido.");
            }

            try
            {
                // Cargar el doctor junto con las relaciones de Location y User
                //var doctor = await _context.Doctor.FindAsync(id);
                var doctor = await _context.Doctor
                .Include(d => d.Location) // Incluye la relación con Location
                .Include(d => d.User)     // Incluye la relación con User
                .FirstAsync(d => d.Id == id);


                if (doctor == null)
                {

                    _logger.LogInformation($"El doctor que buscas no se encontró: {id}");
                    throw new ResourceNotFoundException("El doctor que buscas no se encontró.");
                }

                _logger.LogInformation($"Doctor encontrado: Sede: {doctor.Location?.Location}, Usuario: {doctor.User?.Name}");
                // Mapea el Doctor a un DTO
                return new GetDoctorDto
                {
                    Id = doctor.Id,
                    Specialty = doctor.Specialty,
                    LicenseNumber = doctor.LicenseNumber,
                    Office = doctor.Office,
                    LocationId = doctor.LocationId,
                    Location = doctor.Location.Location,
                    UserId = doctor.UserId,
                    Name = doctor.User.Name,
                    LastName = doctor.User.LastName,
                    BirthDate = doctor.User.BirthDate,
                    Email = doctor.User.Email,
                    Phone = doctor.User.Phone,
                    Role = doctor.User.Role
                };
            }
            catch (ResourceNotFoundException ex)
            {
                _logger.LogWarning($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar obtener el doctor con ID: {Id}", id);
                throw new Exception("Error interno al intentar obtener el doctor por su ID.");
            }
        }
    }
}
