using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface IUserRegistrationRepository
    {
        Task<List<tblUserRegistration>> GetUserLoginDetails(UserRegistrationRequestDTO model);
        Task<bool> CreateUserResgistration(UserRegistrationRequestDTO model);
    }
}
