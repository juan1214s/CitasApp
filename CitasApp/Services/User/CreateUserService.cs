using CitasApp.Context;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;

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

                var user = new UsersEntity
                {
                    Id = userDto.Id,
                    Name = userDto.Name,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    Role = userDto.Role,
                    BirthDate = userDto.BirthDate.Date // Solo la parte de la fecha
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error interno al crear el usuario: {ex.ToString()}");
                return false;
            }
        }
    }
}
