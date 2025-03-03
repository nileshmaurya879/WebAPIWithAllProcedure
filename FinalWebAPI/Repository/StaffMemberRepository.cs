using Dapper;
using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using System.Data;

namespace FinalWebAPI.Repository
{
    public class StaffMemberRepository :  IStaffMemberRepository
    {
        public readonly IDbConnection _dbConnection;
        public StaffMemberRepository(IDbConnection db)
        {
            _dbConnection = db;
        }

        public async Task<IEnumerable<StaffMember>> GetAllStaffMember()
        {
            var result = await _dbConnection.QueryAsync<StaffMember>("sp_GetStaffMember");
            return result.ToList();
        }
    }
}
