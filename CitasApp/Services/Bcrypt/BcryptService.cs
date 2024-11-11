using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace CitasApp.Services.Bcrypt
{
    public class BcryptService
    {
        private readonly int _workFactor;

        //metodo para encriptar la contraseña
        public string HashPasswork(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Método para verificar si la contraseña coincide con el hash
        public bool VerifyPasswork(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
