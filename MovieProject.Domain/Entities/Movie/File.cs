using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Domain.Entities.Movie
{
    public class File
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string? FileName { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
