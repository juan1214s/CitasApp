using CitasApp.Context;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;
using CitasApp.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

public class CreateUserService
{
    private readonly ILogger<CreateUserService> _logger;
    private readonly AppDbContext _context;

    public CreateUserService(AppDbContext context, ILogger<CreateUserService> logger)
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
                // Lanza una excepción personalizada si el usuario ya existe
                throw new UserAlreadyExistsException($"El usuario con ID {userDto.Id} ya está registrado.");
            }

            var user = new UsersEntity
            {
                Id = userDto.Id,
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
        catch (DbUpdateException ex)
        {
            _logger.LogError($"Error interno al crear el usuario: {ex.Message}");
            throw new AppExceptions("Error al guardar cambios en la base de datos.", 500);
        }
    }
}
