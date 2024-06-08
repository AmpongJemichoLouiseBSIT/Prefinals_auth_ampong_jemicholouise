using Microsoft.AspNetCore.Mvc;

namespace Core
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}