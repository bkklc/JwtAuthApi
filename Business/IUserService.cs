using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.UserResponses;
using Entities;


namespace Business
{
    public interface IUserService
    {
        Task<CreatedUserResponse> UserRegister(UserRegisterRequest userRegisterRequest);

    }
}
