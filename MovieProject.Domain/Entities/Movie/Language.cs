using System.ComponentModel.DataAnnotations;

namespace MovieProject.Domain.Entities.Movie
{
    public class Language
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string title { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
