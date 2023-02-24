using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.Interfaces.Movies
{
    public interface IMovieRepository:IRepository<Movie>
    {
        Task<List<Movie>> GetMovieByTittle(string searchKey);
        Task<Movie?> GetMovieEagerLoadAsync(int id);
    }
}
