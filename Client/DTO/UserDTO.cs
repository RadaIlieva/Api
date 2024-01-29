using Autentication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    public class UserDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
