using FinalWebAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMemberController : ControllerBase
    {
        public readonly IStaffMemberRepository _staffMemberRepository;
        public StaffMemberController(IStaffMemberRepository staffMemberRepository) 
        {
            _staffMemberRepository = staffMemberRepository;
        }

        [HttpGet]
        public IActionResult getStaffMemebr()
        {
            var result = _staffMemberRepository.GetAllStaffMember();
            return Ok();
        }
    }
}
