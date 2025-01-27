using CitasApp.Context;
using CitasApp.Dto.Doctor;
using CitasApp.Entityes.Doctor;
using CitasApp.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using CitasApp.Exceptions;

namespace CitasApp.Services.Doctor
{
    public class CreateDoctorService
    { 
        private readonly ILogger<CreateDoctorService> _logger;
        private readonly AppDbContext _context;
        private readonly GetUserByIdService _getUserByIdService;

        public CreateDoctorService(
            AppDbContext context, 
            ILogger<CreateDoctorService> logger,
            GetUserByIdService getUserByIdService
            )
        {
            _context = context;
            _logger = logger;
            _getUserByIdService = getUserByIdService;
        }

        public async Task<bool> CreateDoctor(PostDoctorDto doctorDto)
        {
            try
            {
                // Verificar si el usuario tiene el rol de Doctor
                var userIsDoctor = await _getUserByIdService.GetUserById(doctorDto.UserId);
                if (userIsDoctor.Role != "Doctor")
                {
                    _logger.LogError("El usuario no tiene el rol de Doctor.");
                    throw new AccessNotReSource("El usuario proporcionado no tiene el rol de Doctor.");
                }

                // Verificar si el usuario existe
                var existUserId = await _context.User.FirstOrDefaultAsync(u => u.Id == doctorDto.UserId);
                if (existUserId == null)
                {
                    _logger.LogError("El usuario no existe.");
                    throw new ResourceNotFoundException("El usuario no existe, ingresa uno válido.");
                }

                // Verificar si el número de licencia ya existe
                var existingDoctor = await _context.Doctor.FirstOrDefaultAsync(d => d.LicenseNumber == doctorDto.LicenseNumber);
                if (existingDoctor != null)
                {
                    _logger.LogError("El número de licencia ya existe para otro doctor.");
                    throw new ResourceAlreadyExistsException("El número de licencia ya está en uso por otro doctor.");
                }

                // Crear el nuevo perfil de doctor
                var doctor = new DoctorEntity
                {
                    Specialty = doctorDto.Specialty,
                    LicenseNumber = doctorDto.LicenseNumber,
                    Office = doctorDto.Office,
                    UserId = doctorDto.UserId,
                    LocationId = doctorDto.LocationId
                };

                _context.Add(doctor);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Se creó correctamente el perfil del doctor.");
                return true;
            }
            catch (AppExceptions ex)
            {
                _logger.LogWarning($"Excepción personalizada: {ex.Message}");
                throw;  // Deja que la excepción personalizada sea manejada por el controlador
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al intentar crear el perfil del doctor: {ex}");
                throw new Exception("Ocurrió un error al crear el perfil del doctor.");
            }
        }



    }
}
