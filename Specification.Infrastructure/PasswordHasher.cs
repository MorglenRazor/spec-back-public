using Specification.Application.Interfaces.Auth;

namespace Specification.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static string GenerateStatic(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);


    }
}
