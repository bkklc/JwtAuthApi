using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Core;
using DataAccess.Abstracts;
using Entities;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;



        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;

        }

        public async Task<String> Login(UserLoginRequest userLoginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(userLoginRequest.Email);
            if (user == null)
                return null;


            var hashedInput = PasswordHash.HashPassword(userLoginRequest.Password);
            if (user.PasswordHash != hashedInput)
                return null;

            var token = _tokenService.CreateToken(
            user.Id,
            user.Email
            );

            return token;
        }

       
    }
}
