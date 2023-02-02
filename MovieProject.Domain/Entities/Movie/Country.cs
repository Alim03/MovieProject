using System.ComponentModel.DataAnnotations;

namespace MovieProject.Domain.Entities.Movie
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string title { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
