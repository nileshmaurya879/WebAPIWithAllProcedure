using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface IUserRegistrationRepository
    {
        Task<List<tblUserRegistration>> GetUserLoginDetails(UserLoginRequestDto model);
        Task<bool> CreateUserResgistration(UserRegistrationRequestDTO model);
       // Task<int> GetTest001();

    }
}
