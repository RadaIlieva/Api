using Autentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using Autentication.Enums;
using Autentication.Services.Interfaces;

namespace Autentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AutenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            User user = authenticationService.Register(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            string token = authenticationService.Login(request);
            return Ok(token);
        }
    }
}
