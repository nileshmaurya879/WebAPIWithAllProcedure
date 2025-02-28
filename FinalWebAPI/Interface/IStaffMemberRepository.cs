using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface IStaffMemberRepository
    {
        Task<IEnumerable<StaffMember>> GetAllStaffMember();
    }
}
