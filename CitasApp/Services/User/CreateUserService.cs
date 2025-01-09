using CitasApp.Context;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;
using CitasApp.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Services.User
{
    public class CreateUserService
    {
        private readonly ILogger<CreateUserService> _logger;
        private readonly AppDbContext _context;

        public CreateUserService(
            AppDbContext context, 
            ILogger<CreateUserService> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> CreateUser(CreateUserDto userDto)
        {
            try
            {
                var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Id == userDto.Id);

                if (existingUser != null)
                {
                    // Lanza la excepción personalizada cuando el usuario ya existe
                    throw new Exceptions.UserAlreadyExistsException($"El usuario con ID {userDto.Id} ya está registrado.");
                }

                var user = new UsersEntity
                {
                    Name = userDto.Name,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    Role = userDto.Role,
                    BirthDate = userDto.BirthDate.Date
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exceptions.UserAlreadyExistsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error interno al crear el usuario: {ex.Message}");
                throw new AppExceptions("Ocurrió un error al intentar crear el usuario."); // Lanza una excepción genérica si hay otro error
            }
        }

    }
}
