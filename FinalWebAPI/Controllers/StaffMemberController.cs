using FinalWebAPI.Interface;
using FinalWebAPI.Models;
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
        public async Task<IActionResult> GetStaffMemebr()
        {
            var result = await _staffMemberRepository.GetAllStaffMember();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaffMemebr([FromBody]AddStaffMember addStaff)
        {
            var result = await _staffMemberRepository.AddStaffMember(addStaff);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStaffMemebr(int id)
        {
            var result = await _staffMemberRepository.DeleteStaffMember(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaffMemebr([FromBody] AddStaffMember addStaff)
        {
            var result = await _staffMemberRepository.UpdateStaffMemebr(addStaff);
            return Ok(result);
        }

        [HttpGet("GetStaffMemberById")]
        public async Task<IActionResult> GetStaffMemberById(int id)
        {
            var result = await _staffMemberRepository.GetStaffMemberById(id);
            return Ok(result);
        }
    }
}
