using Microsoft.EntityFrameworkCore;
using MovieProject.Data.Context;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Interfaces.Artists;
using MovieProject.Domain.Interfaces.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories.Movies
{
    public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieProjectDbContext context) : base(context) { }

 
        public async Task<Movie?> GetMovieEagerLoadAsync(int id)
        {
            var aaa = await Context.Movies
                .Include(a => a.Languages).Include(a => a.Artists).Include(a=>a.Countries).Include(a=>a.Genres)
                .SingleOrDefaultAsync(a => a.Id == id);
            return aaa;
        }

        public async Task<List<Movie>> GetMovieByTittle(string searchKey)
        {
            return await Context.Movies.Where(p => p.Title == searchKey).ToListAsync();
        }

        public override  void Update(Movie movie)
        {
            var MovieInDb =  GetMovieEagerLoad(movie.Id);
            if (MovieInDb != null)
            {
                MovieInDb.Title = movie.Title;
                MovieInDb.Time = movie.Time;
                MovieInDb.Image = movie.Image;
                MovieInDb.Summary = movie.Summary;
                MovieInDb.CreatedDate = movie.CreatedDate;
                MovieInDb.ReleasedDate = movie.ReleasedDate;
          
                foreach (var artist in movie.Artists)
                {
                    MovieInDb.Artists.Add(artist);
                }

                foreach (var lang in movie.Languages)
                {
                    MovieInDb.Languages.Add(lang);
                }

                foreach (var country in movie.Countries)
                {
                    MovieInDb.Countries.Add(country);
                }

                foreach (var genre in movie.Genres)
                {
                    MovieInDb.Genres.Add(genre);
                }
            }
        }

        public  Movie? GetMovieEagerLoad(int id)
        {
            return  Context.Movies.Include(a => a.Languages).Include(a => a.Countries).Include(a => a.Artists).Include(a => a.Genres).SingleOrDefault(a => a.Id == id);

            //var lang = Context.Movies.Include(a => a.Languages).SingleOrDefault(a => a.Id == id);
            //var country = Context.Movies.Include(a => a.Countries).SingleOrDefault(a => a.Id == id);
            //var artist = Context.Movies.Include(a => a.Artists).SingleOrDefault(a => a.Id == id);
            //var genre = Context.Movies.Include(a => a.Genres).SingleOrDefault(a => a.Id == id);
        }








    }
}
