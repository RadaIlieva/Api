using Autentication.Enums;
using Autentication.Models;
using Autentication.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public User Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                Role = request.Role == UserRole.Admin ? UserRole.Admin : UserRole.User
            };


            return user;
        }

        public string Login(UserDto request)
        {
            User user = new User
            {
                Username = request.Username,
                Role = request.Role
            };

            string token = user.Role == UserRole.Admin ? CreateAdminToken(user) : CreateUserToken(user);

            return token;
        }

        private string CreateAdminToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, UserRole.Admin.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetRequiredSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string CreateUserToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, UserRole.User.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetRequiredSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
