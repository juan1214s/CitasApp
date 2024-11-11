using CitasApp.Context;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;
using CitasApp.Services.Bcrypt;

namespace CitasApp.Services.User
{
    public class CreateUserService
    {
        private readonly ILogger<CreateUserService> _logger;
        private readonly AppDbContext _context;
        private readonly BcryptService _bcryptService;

        public CreateUserService(
            AppDbContext context, 
            ILogger<CreateUserService> logger, 
            BcryptService bcryptService
            )
        {
            _context = context;
            _logger = logger;
            _bcryptService = bcryptService;
        }

        public async Task<bool> CreateUser(CreateUserDto userDto)
        {
            try
            {

                string hashedPassword = _bcryptService.HashPasswork(userDto.Password);

                var user = new UsersEntity
                {
                    Name = userDto.Name,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Password = hashedPassword,
                    Phone = userDto.Phone,
                    Role = userDto.Role
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
