namespace FinalWebAPI.Models
{
    public class UserRegistrationDTO
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
    }

    public class UserRegistrationRequestDTO
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserLoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
