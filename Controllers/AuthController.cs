using Microsoft.AspNetCore.Mvc;
using PhysiqueAnalyzerApi.DTOs;
using PhysiqueAnalyzerApi.Services;

namespace PhysiqueAnalyzerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("signup")]
        public IActionResult Signup(RegisterRequest request)
        {
            var user = _userService.Create(request.Username, request.Password);
            if (user == null)
                return BadRequest(new { message = "Username already exists" });
            return Ok(new { message = "User created" });
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _userService.GetByUsername(request.Username);
            if (user == null || !_userService.CheckPassword(user, request.Password))
                return Unauthorized(new { message = "Invalid username or password" });
            var token = _tokenService.GenerateToken(user);
            return Ok(new AuthResponseDto
            {
                Username = user.Username,
                Token = token
            });
        }
    }
}