using Dapper;
using FinalWebAPI.Interface;
using FinalWebAPI.Models;
using Microsoft.Data.SqlClient;
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

        public async Task<bool> AddStaffMember(AddStaffMember addStaffMember)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@MemberName", addStaffMember.MemberName);
            parameters.Add("@MemberMobileNo", addStaffMember.Mobile);
            parameters.Add("@StaffAddress", addStaffMember.StaffAddress);
            parameters.Add("@MemberServices", addStaffMember.MemberServices);
            parameters.Add("@Salary", addStaffMember.Salary);


            var result = await _dbConnection.QueryAsync("sp_AddStaffMember", parameters, commandType:CommandType.StoredProcedure, commandTimeout: 3000);
            return true;
        }

        public async Task<bool> DeleteStaffMember(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
           
            var result = await _dbConnection.QueryAsync("sp_DeleteStaffMember", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
            return true;
        }

        public async Task<bool> UpdateStaffMemebr(AddStaffMember addStaffMember)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", addStaffMember.Id);
            parameters.Add("@MemberName", addStaffMember.MemberName);
            parameters.Add("@Mobile", addStaffMember.Mobile);
            parameters.Add("@StaffAddress", addStaffMember.StaffAddress);
            parameters.Add("@MemberServices", addStaffMember.MemberServices);
            parameters.Add("@Salary", addStaffMember.Salary);

            var result = await _dbConnection.QueryAsync("sp_UpdateStaffMember", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
            return true;
        }

        public async Task<StaffMember> GetStaffMemberById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = await _dbConnection.QueryAsync<StaffMember>("sp_GetStaffMemberById", parameters, commandType: CommandType.StoredProcedure, commandTimeout: 3000);
            return result.FirstOrDefault();
        }

    }
}
