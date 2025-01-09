using CitasApp.Dto.UserDto;
using CitasApp.Services.User;
using CitasApp.Services.Exceptions;  // Agregar esta línea
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("JMSCITAS/usuarios")]
public class CreateUserController : ControllerBase
{
    private readonly CreateUserService _createUserService;
    private readonly ILogger<CreateUserController> _logger;

    public CreateUserController(CreateUserService createUserService, ILogger<CreateUserController> logger)
    {
        _createUserService = createUserService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        if (userDto == null)
        {
            _logger.LogWarning("Se intentó crear un usuario con datos nulos.");
            return BadRequest("Se requieren todos los datos para crear el usuario.");
        }

        try
        {
            var result = await _createUserService.CreateUser(userDto);

            if (result)
            {
                _logger.LogInformation("Usuario creado con éxito.");
                return Ok(new { message = "Se creó con éxito el usuario." });
            }
            else
            {
                _logger.LogError("Error al crear el usuario.");
                return BadRequest(new { error = "Error al crear el usuario." });
            }
        }
        catch (UserAlreadyExistsException ex)  // Ajusta la excepción aquí
        {
            // Deja que el middleware maneje las excepciones personalizadas
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error interno al intentar crear un usuario.");
            return StatusCode(500, new { error = "Error interno al intentar crear el usuario." });
        }
    }
}
