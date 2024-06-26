using SharedClassLibrary.DTOs;
using static SharedClassLibrary.DTOs.ServiceResponses;

namespace SharedClassLibrary.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> Createaccount(UserDto userDto);
        Task<LoginResponse> LoginAccount(LoginDTO loginDto);
    }
}
