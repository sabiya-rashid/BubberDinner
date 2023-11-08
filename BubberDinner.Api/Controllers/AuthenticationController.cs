using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationServices _authenticationServices;

        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationServices.Register(
                request.firstName,
                request.lastName,
                request.email,
                request.password
                );
            var response = new AuthenticationResponse(
                authResult.id,
                authResult.firstName,
                authResult.lastName,
                authResult.email,
                authResult.token
                );
                return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationServices.Login(
                request.email,
                request.password
                );
            var response = new AuthenticationResponse(
                authResult.id,
                authResult.firstName,
                authResult.lastName,
                authResult.email,
                authResult.token
                );
            return Ok(response);
        }
    }
}
