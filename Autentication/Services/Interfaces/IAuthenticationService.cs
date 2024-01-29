using Autentication.Models;

namespace Autentication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User Register(UserDto request);
        string Login(UserDto request);
    }
}
