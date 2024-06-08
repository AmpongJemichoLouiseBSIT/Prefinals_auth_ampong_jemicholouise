using Microsoft.AspNetCore.Mvc;

namespace Core
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        bool ValidateJwtToken(string token);
    }
}
