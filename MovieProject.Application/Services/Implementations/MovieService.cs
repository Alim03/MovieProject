using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Interfaces;

namespace MovieProject.Application.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Genre> _repository;

        public MovieService(IRepository<Genre> repository)
        {
            _repository = repository;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _repository.AddAsync(genre);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task RemoveGenre(Genre genre)
        {
            _repository.Remove(genre);
            await _repository.SaveAsync();
        }
    }
}
