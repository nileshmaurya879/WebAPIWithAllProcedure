using FinalWebAPI.Models;

namespace FinalWebAPI.Interface
{
    public interface IStaffMemberRepository
    {
        Task<IEnumerable<StaffMember>> GetAllStaffMember();
        Task<bool>AddStaffMember(AddStaffMember addStaffMember);
        Task<bool> DeleteStaffMember(int id);
        Task<bool> UpdateStaffMemebr(AddStaffMember addStaffMember);
        Task<StaffMember> GetStaffMemberById(int id);
    }
}
