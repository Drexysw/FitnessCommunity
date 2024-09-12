using System.Security.Cryptography;
using FitnessCommunity.Application.Abstractions;

namespace FitnessCommunity.Infrastructure.Database.Abstractions
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA3_512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool VerifyPassword(string hash, string password)
        {
            string[] parts = hash.Split('-');
            byte[] storedHash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);
            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, storedHash.Length);
            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }
    }
}
