using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Entities;



namespace Business
{
    public interface IAuthService
    {      
        Task<String> Login(UserLoginRequest userLoginRequest);
        Task<CreatedUserResponse> Register(UserRegisterRequest userRegisterRequest);


    }
}
