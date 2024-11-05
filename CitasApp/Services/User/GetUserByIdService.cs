﻿using CitasApp.Context;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;
using Microsoft.Extensions.Logging;

namespace CitasApp.Services.User
{
    public class GetUserByIdService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetUserByIdService> _logger;

        public GetUserByIdService(AppDbContext context, ILogger<GetUserByIdService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            if (id < 0)
            {
                _logger.LogWarning("Se intentó obtener un usuario con un ID inválido: {Id}", id);
                throw new ArgumentException("El ID del usuario no puede ser negativo.", nameof(id));
            }

            try
            {
                var user = await _context.User.FindAsync(id);

                if (user == null)
                {
                    _logger.LogInformation("No se encontró un usuario con ID: {Id}", id);
                    return null; 
                }

                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Phone = user.Phone,
                    Role = user.Role
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar obtener el usuario con ID: {Id}", id);
                throw; 
            }
        }
    }
}