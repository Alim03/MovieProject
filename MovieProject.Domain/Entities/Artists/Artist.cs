using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MovieProject.Domain.Entities.Artists
{
    public class Artist
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public string? Image { get; set; }
        public DateTime BirthDate { get; set; }

        [MaxLength(1024)]
        public string? Bio { get; set; }
        public ICollection<Career> Careers { get; set; }
        public ICollection<Movie.Movie> Movies { get; set; }
    }
}
