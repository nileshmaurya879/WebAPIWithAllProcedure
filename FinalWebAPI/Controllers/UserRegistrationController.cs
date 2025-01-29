using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        public UserRegistrationController()
        {

        }

        [HttpGet]
        public Task<IActionResult> GetUserLogin()
        {
            return null;
        }
    }
}
