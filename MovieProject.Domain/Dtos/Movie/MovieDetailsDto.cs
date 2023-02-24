using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.Dtos.Movie
{
    public class MovieDetailsDto
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Career> Careers { get; set; }
        public IEnumerable<Language> languages { get; set; }
        public IEnumerable<Country> Countrys { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
            
    }
}
