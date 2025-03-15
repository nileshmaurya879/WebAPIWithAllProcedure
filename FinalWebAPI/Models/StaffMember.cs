namespace FinalWebAPI.Models
{
    public class StaffMember
    {
        public int? SrNo { get; set; }
        public int? Id { get; set; }
        public string? MemberName { get; set; }
        public long? Mobile { get; set; }
        public string? StaffAddress { get; set; }
        public string? MemberServices { get; set; }
        public decimal? Salary { get; set; }
    }

    public class AddStaffMember
    {
        public int? Id { get; set; }
        public string? MemberName { get; set; }
        public long? Mobile { get; set; }
        public string? StaffAddress { get; set; }
        public string? MemberServices { get; set; }
        public decimal? Salary { get; set; }
    }
}
