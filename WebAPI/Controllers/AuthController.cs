using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegister)
        {
            var userToCheck = _authService.UserExists(userForRegister.Email);
            if (!userToCheck.Success)
            {
                return BadRequest(userToCheck.Message);
            }
            var registerResult = _authService.Register(userForRegister);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLogin) 
        { 
            var loginResult = _authService.Login(userForLogin);
            if (!loginResult.Success)
            {
                return BadRequest(loginResult.Message);
            }
            var result = _authService.CreateAccessToken(loginResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
