
using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinalWebAPI.Repository
{
    public class UserRegistrationRepository:IUserRegistrationRepository
    {
        public readonly CategoryDBContext _categoryDBContext;
        public UserRegistrationRepository(CategoryDBContext categoryDBContext) 
        {
            _categoryDBContext = categoryDBContext;
        }

        public async Task<List<tblUserRegistration>> GetUserLoginDetails(UserLoginRequestDto model)
        {
            var em = new SqlParameter("@email", model.Email);
            var pass = new SqlParameter("@password", model.Password);

            var result = await _categoryDBContext.tblUserRegistration.FromSqlRaw(@"exec sp_GetLoginUserDetails @Email,@Password", em, pass).ToListAsync();
            return result;
           
        }

        public async Task<bool> CreateUserResgistration(UserRegistrationRequestDTO model)
        {
            var username = new SqlParameter("@UserName", model.UserName);
            var em = new SqlParameter("@email", model.Email);
            var pass = new SqlParameter("@password", model.UserPassword);

            var result = await _categoryDBContext.Database.ExecuteSqlRawAsync(@"exec sp_CreateUserRegistration @UserName, @Email,@Password", username, em, pass);
            return true;

        }
    }
}
