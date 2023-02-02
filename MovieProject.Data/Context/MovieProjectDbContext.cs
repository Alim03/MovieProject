using Microsoft.EntityFrameworkCore;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;

namespace MovieProject.Data.Context
{
    public class MovieProjectDbContext : DbContext
    {
        public MovieProjectDbContext(DbContextOptions<MovieProjectDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Domain.Entities.Movie.File> Files { get; set; }
    }
}
