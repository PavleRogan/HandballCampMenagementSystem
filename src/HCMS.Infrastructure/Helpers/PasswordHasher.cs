using HCMS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Infrastructure.Helpers
{
    internal class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;
        private const char Delimiter = ';';
        private readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;



        public string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, HashSize);
            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            var passwordElements = hashedPassword.Split(Delimiter);

            var hash = Convert.FromBase64String(passwordElements[1]);

            var salt = Convert.FromBase64String(passwordElements[0]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
