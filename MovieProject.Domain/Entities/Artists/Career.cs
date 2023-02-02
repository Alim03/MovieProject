using System.ComponentModel.DataAnnotations;

namespace MovieProject.Domain.Entities.Artists
{
    public class Career
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
