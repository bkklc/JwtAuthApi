using Business;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<CreatedUserResponse>> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var createdUser = await _userService.UserRegister(userRegisterRequest);
            return Ok(createdUser);
        } 

    }
}
