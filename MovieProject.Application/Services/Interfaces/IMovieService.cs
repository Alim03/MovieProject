using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Entities.Movie;

namespace MovieProject.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task AddGenreAsync(Genre genre);
        Task RemoveGenre(Genre genre);
        Task<IEnumerable<Genre>> GetAllGenreAsync();
    }
}