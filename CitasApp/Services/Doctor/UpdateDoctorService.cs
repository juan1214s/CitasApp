using AutoMapper;
using CitasApp.Context;
using CitasApp.Dto.Doctor;
using CitasApp.Exceptions;

namespace CitasApp.Services.Doctor
{
    public class UpdateDoctorService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UpdateDoctorService> _logger;
        private readonly IMapper _mapper;

        public UpdateDoctorService(AppDbContext context, ILogger<UpdateDoctorService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> UpdateDoctor(int id, UpdateDoctorDto doctorDto)
        {

            if (doctorDto == null) 
            {
                _logger.LogWarning("Los datos del doctor no pueden estar vacios.");
                throw new ArgumentNullException(nameof(doctorDto), "Los datos del doctor no pueden estar vacios.");
            }


            try
            {
                var existingDoctor = await _context.Doctor.FindAsync(id);

                if (existingDoctor == null)
                {
                    _logger.LogInformation("El perfil del medico que intentas actualizar no existe.");
                    throw new ResourceNotFoundException("El perfil del medico que intentas actualizar no existe.");
                }

                _mapper.Map(doctorDto, existingDoctor);
                await _context.SaveChangesAsync();

                return true;
            }
            catch ( ArgumentException ex )
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al actualizar el perfil del medico: {ex}");
                throw;
            }
        }
    }
}
