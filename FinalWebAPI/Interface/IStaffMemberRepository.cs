using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface IStaffMemberRepository
    {
        Task<IEnumerable<StaffMember>> GetAllStaffMember();
        Task<bool>AddStaffMember(AddStaffMember addStaffMember);
    }
}
