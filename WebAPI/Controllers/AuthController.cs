using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLogin) {
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success) {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success) {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegister) { 
            var userToRegister = _authService.Register(userForRegister);
            if (!userToRegister.Success) {  
                return BadRequest(userToRegister); 
            }

            var result = _authService.CreateAccessToken(userToRegister.Data);
            if (!result.Success) {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}
