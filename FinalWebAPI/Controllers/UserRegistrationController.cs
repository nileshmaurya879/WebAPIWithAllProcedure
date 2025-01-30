using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebAPI.Controllers
{
    [Route("api/UserRegistration")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        public readonly IUserRegistrationRepository _userRegistrationRepository;
        public UserRegistrationController(IUserRegistrationRepository userRegistrationRepository)
        {
            _userRegistrationRepository = userRegistrationRepository;
        }

        [HttpPost("GetUserLogin")]
        public async Task<IActionResult> GetUserLogin([FromBody]UserRegistrationRequestDTO model)
        {
            var result =await _userRegistrationRepository.GetUserLoginDetails(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserResgistration(UserRegistrationRequestDTO model)
        {
            var result = await _userRegistrationRepository.CreateUserResgistration(model);
            return Ok(result);
        }
    }
}
