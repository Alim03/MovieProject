using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Entities.Account;

namespace MovieProject.Domain.Entities.Movie
{
    public class Comment
    {
        public int Id { get; set; }

        [MaxLength(1024)]
        public string Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
