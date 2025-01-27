using CitasApp.Context;
using CitasApp.Dto.LocationDto;
using CitasApp.Entityes.Location;
using CitasApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Services.Locations
{
    public class CreateLocationService
    {
        private readonly ILogger<CreateLocationService> _logger;
        private readonly AppDbContext _context;

        public CreateLocationService(ILogger<CreateLocationService> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateLocation(CreateLocationDto locationDto)
        {
            try
            {
                var existLocation = await _context.Location.FirstOrDefaultAsync(l => l.Location == locationDto.Location);

                if (existLocation != null)
                {
                    _logger.LogError("La ubicacion ya exise.");
                    throw new ResourceAlreadyExistsException($"Ya la ubicacion que intentas ingresar existe.");
                }

                var location = new LocationEntity
                {
                    Location = locationDto.Location
                };

                _context.Add(location);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Se creo correcamente la nueva sede.");
                return true;
            }
            catch (AppExceptions ex)
            {
                _logger.LogWarning($"Error al crear la ubicacion.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrio un error al crear la ubicacion de la sede: {ex.Message}");
                throw;
            }
        }
    }
}
