using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Entities.Artists;

namespace MovieProject.Domain.Entities.Movie
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleasedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int? Time { get; set; }

        [MaxLength(128)]
        public string? Image { get; set; }

        [MaxLength(128)]
        public string? Cover { get; set; }

        [MaxLength(512)]
        public string? Summary { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
