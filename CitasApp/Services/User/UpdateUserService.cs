using AutoMapper;
using CitasApp.Context;
using CitasApp.Dto.UserDto;
using Microsoft.Extensions.Logging;

namespace CitasApp.Services.User
{
    public class UpdateUserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UpdateUserService> _logger;
        private readonly IMapper _mapper;

        public UpdateUserService(
            AppDbContext context,
            ILogger<UpdateUserService> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> UpdateUser(int id, UpdateUserDto userDto)
        {
            if (userDto == null)
            {
                _logger.LogWarning("Los datos del usuario para la actualización son nulos.");
                throw new ArgumentNullException(nameof(userDto), "Los datos del usuario no pueden ser nulos.");
            }

            try
            {
                var existingUser = await _context.User.FindAsync(id);

                if (existingUser == null)
                {
                    _logger.LogInformation("El usuario que se busca no existe.");
                    throw new ArgumentException("El usuario no existe.");
                }

                _mapper.Map(userDto, existingUser);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno al actualizar el usuario.");
                throw;
            }
        }
    }
}
