namespace FinalWebAPI.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Operation { get; set; }
    }

    public class LoginUser
    {
        public string Email { get; set; }
        public int Password { get; set; }
    }
}
