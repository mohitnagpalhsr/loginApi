using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BCrypt.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SportsEventManagementContext _userContext;
        private readonly ITokenService _tokenService;

        public AuthController(SportsEventManagementContext userContext, ITokenService tokenService)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = _userContext.LoginModels.SingleOrDefault(x => x.Username == loginModel.Username);
            
            bool verified = BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password);
            
            if (user == null || !verified)
                return Unauthorized();

            var role=user.Role;


            // if (user is null)
            //     return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username),
                new Claim(ClaimTypes.Role, role)
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            _userContext.SaveChanges();

            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                Role=role
            });
        }
    }
}