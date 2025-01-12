﻿namespace CitasApp.Services.Exceptions
{
    // Aquí definimos todas las excepciones personalizadas que se utilizarán en los controladores o servicios

    // Clase base para excepciones personalizadas, que hereda de Exception.
    // Permite agregar un código de estado HTTP (por defecto 500 para errores internos del servidor).
    public class AppExceptions : Exception
    {
        public int StatusCode { get; }  // Propiedad que guarda el código de estado HTTP

        // Constructor que recibe el mensaje de error y un código de estado opcional (por defecto 500).
        public AppExceptions(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;  // Establece el código de estado HTTP
        }
    }

    // Excepción personalizada para indicar que un usuario ya existe.
    // Se utiliza un código de estado HTTP 409 (Conflict).
    public class UserAlreadyExistsException : AppExceptions
    {
        // Constructor que recibe el mensaje de error y lo pasa al constructor base con el código de estado 409.
        public UserAlreadyExistsException(string message) : base(message, 409) { }
    }

    // Excepción personalizada para cuando una entidad no se encuentra (por ejemplo, un usuario o doctor no encontrado).
    // Se utiliza un código de estado HTTP 404 (Not Found).
    public class EntityNotFoundException : AppExceptions
    {
        // Constructor que recibe el mensaje de error y lo pasa al constructor base con el código de estado 404.
        public EntityNotFoundException(string message) : base(message, 404) { }
    }

    // Excepción personalizada para cuando el número de licencia ya existe en la base de datos (para doctores).
    // Se utiliza un código de estado HTTP 409 (Conflict).
    public class LicenseNumberAlreadyExistsException : AppExceptions
    {
        // Constructor que recibe el mensaje de error y lo pasa al constructor base con el código de estado 409.
        public LicenseNumberAlreadyExistsException(string message) : base(message, 409) { }
    }

    // Excepción personalizada para indicar que el usuario no tiene el rol de Doctor.
    // Se utiliza un código de estado HTTP 403 (Forbidden).
    public class UserNotDoctorException : AppExceptions
    {
        // Constructor que recibe el mensaje de error y lo pasa al constructor base con el código de estado 403.
        public UserNotDoctorException(string message) : base(message, 403) { }
    }

    // Excepción personalizada para indicar que un recurso no se encuentra.
    // Se utiliza el código de estado HTTP 404 (Not Found).
    public class ResourceNotFoundException : AppExceptions
    {
        // Constructor que recibe un mensaje de error y lo pasa al constructor base con el código de estado 404.
        public ResourceNotFoundException(string message) : base(message, 404) { }
    }
}
