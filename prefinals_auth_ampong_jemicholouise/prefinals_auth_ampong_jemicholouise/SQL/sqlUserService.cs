using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core;
using prefinals_auth_ampong_jemicholouise.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.SQL
{
    public class sqlUserService : IUserService
    {
        private readonly DbContext _context;

        public sqlUserService(DbContext context)
        {
            _context = context;
        }

        // GET: Users
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User GetUserByEmail(String Email)
        {
            return _context.Users.FirstorDefault(u => u.Email == email);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            var user = _context.Users.Find(userID);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
        public class SqlAuthService : IAuthService
        {
            private readonly SymmetricSecurityKey _key;

            public SqlAuthService(string secretKey)
            {
                _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            }

            public string GenerateJwtToken(User user)
            {
                var token = new JwtSecurityToken(
                    claims: new[] { new Claim(ClaimTypes.Name, user.Username) },
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public bool ValidateJwtToken(string token)
            {
                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                try
                {
                    new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParams, out _);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

        