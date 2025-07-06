using Business;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var token = await _authService.Login(userLoginRequest);
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Geçersiz kimlik bilgisi.");

            return Ok(token);

        }

        [HttpPost("Register")]
        public async Task<ActionResult<CreatedUserResponse>> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var createdUser = await _authService.Register(userRegisterRequest);
            return Ok(createdUser);
        }

    }
}
