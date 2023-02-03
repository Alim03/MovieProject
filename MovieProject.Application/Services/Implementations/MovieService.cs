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

        public async Task<Genre?> GetGenreAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _repository.AddAsync(genre);
            await _repository.SaveAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _repository.Update(genre);
            await _repository.SaveAsync();
        }

        public async Task RemoveGenreByIdAsync(int id)
        {
            var genre = await _repository.GetAsync(id);
            if (genre != null)
            {
                _repository.Remove(genre);
                await _repository.SaveAsync();
            }
        }

        public async Task RemoveGenre(Genre genre)
        {
            _repository.Remove(genre);
            await _repository.SaveAsync();
        }
    }
}
