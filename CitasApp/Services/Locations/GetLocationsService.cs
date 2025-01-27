using CitasApp.Context;
using CitasApp.Dto.LocationDto;
using Microsoft.EntityFrameworkCore;
using CitasApp.Exceptions;

namespace CitasApp.Services.Locations
{
    public class GetLocationsService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetLocationsService> _logger;

        public GetLocationsService(AppDbContext context, ILogger<GetLocationsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<GetLocationDto>> GetLocations()
        {
            try
            {
                // Obtener todas las ubicaciones de la base de datos
                var locations = await _context.Location.ToListAsync();

                // Verificar si no se encontraron ubicaciones
                if (!locations.Any())
                {
                    _logger.LogWarning("No hay ubicaciones registradas.");
                    throw new ResourceNotFoundException("No hay ubicaciones registradas.");
                }

                // Convertir las ubicaciones a DTOs
                var locationDtos = locations.Select(location => new GetLocationDto
                {
                    Id = location.Id
                }).ToList();

                _logger.LogInformation("Se obtuvieron las ubicaciones correctamente.");
                return locationDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las ubicaciones: {ex}");
                throw new Exception("Error interno al obtener las ubicaciones.");
            }
        }
    }
}
