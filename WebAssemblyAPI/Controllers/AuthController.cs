using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAssemblyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginService _loginService;

        public AuthController(IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserDto>> LoginUserAsync(UserDto userDto)
        {
            var audience = _config.GetSection("AppSettings")["ValidAudience"];
            var issuer = _config.GetSection("AppSettings")["ValidIssuer"];
            var secret = _config.GetSection("AppSettings")["Secret"];

            var result = await _loginService.Authenticate(userDto.Mail, userDto.Password, audience, issuer, secret);

            return result;
        }  
    }
}
