
using FinalWebAPI.Interface;
using FinalWebAPI.Models;

namespace FinalWebAPI.Repository
{
    public class UserRegistrationRepository
    {
        public readonly ICategoryRepository _categoryRepository;
        public UserRegistrationRepository(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<UserRegistrationDTO>> GetUserLoginDetails()
        {

            return null;
        }
    }
}
