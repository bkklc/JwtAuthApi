
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Core;
using DataAccess.Abstracts;
using Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        

        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
            
        }

        public async Task<CreatedUserResponse> UserRegister(UserRegisterRequest userRegisterRequest)
        {

            if (await _userRepository.ExistsByEmailAsync(userRegisterRequest.Email))
            {
                throw new InvalidOperationException("User with this email already exists.");
            }

            var hashedPassword = PasswordHash.HashPassword(userRegisterRequest.Password);

            var user = new User
            {
                FirstName = userRegisterRequest.FirstName,
                LastName = userRegisterRequest.LastName,
                Email = userRegisterRequest.Email,
                PasswordHash = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(user);
            return new CreatedUserResponse
            {
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };
        }

       

    }
}
