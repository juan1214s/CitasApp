﻿using CitasApp.Dto.UserDto;
using CitasApp.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using CitasApp.Exceptions;

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
                return StatusCode(201, new { message = "Se creó con éxito el usuario." });
            }
            else
            {
                _logger.LogError("Error al crear el usuario.");
                return BadRequest(new { error = "Error al crear el usuario." });
            }
        }
        catch (ResourceAlreadyExistsException ex) 
        {
            // Deja que el middleware maneje las excepciones personalizadas
            return Conflict(new { message = ex.Message });
        }
        catch (AppExceptions ex)
        {
            _logger.LogError(ex.Message); // Registra el mensaje de la excepción personalizada.
            return StatusCode(ex.StatusCode, new { error = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error interno al intentar crear un usuario.");
            return StatusCode(500, new { error = "Error interno al intentar crear el usuario." });
        }
    }
}
