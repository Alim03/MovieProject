using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Entities.Movie;

namespace MovieProject.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Genre?> GetGenreAsync(int id);
        Task<IEnumerable<Genre>> GetAllGenreAsync();
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task RemoveGenre(Genre genre);
        Task RemoveGenreByIdAsync(int id);
    }
}
