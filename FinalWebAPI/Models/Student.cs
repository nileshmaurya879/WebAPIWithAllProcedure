namespace FinalWebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public int StudentRollNo { get; set; }
    }

    public class tblUser
    {
        public string Email { get; set; }
        public int Password { get; set; }
    }
    public class tblUserRegistration
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }
}
