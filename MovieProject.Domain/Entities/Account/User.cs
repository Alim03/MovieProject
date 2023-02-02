using System.ComponentModel.DataAnnotations;
using MovieProject.Domain.Entities.Movie;

namespace MovieProject.Domain.Entities.Account
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
