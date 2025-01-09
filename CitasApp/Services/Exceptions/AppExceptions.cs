namespace CitasApp.Services.Exceptions
{
    //aca ingreso todas las excepciones personalizadas para los controladores o servicios

    public class AppExceptions : Exception
    {
        public int StatusCode { get; }
        public AppExceptions(string message, int statusCode = 500 ) : base (message)
            {
                StatusCode = statusCode;
            }
    }

    public class UserAlreadyExistsException : AppExceptions
    { 
        public UserAlreadyExistsException(string message) : base(message, 409) { }
    }

    public class EntityNotFoundException : AppExceptions
    {
        public EntityNotFoundException(string message) : base(message, 404) { }
    }

}
