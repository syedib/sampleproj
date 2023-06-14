using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace WebApi.Utils
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password) 
            => BCrypt.Net.BCrypt.HashPassword(password);

        public static bool Verify(string password, string hashedPassword) 
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
