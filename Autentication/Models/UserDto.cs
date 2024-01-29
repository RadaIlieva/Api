using Autentication.Enums;

namespace Autentication.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
