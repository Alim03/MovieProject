namespace MovieProject.WebApi.Dtos
{
    public class RegisterUserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
