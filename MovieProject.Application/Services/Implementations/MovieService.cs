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
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Country> _countryRepository;

        public MovieService(
            IRepository<Genre> genreRepository,
            IRepository<Language> languageRepository,
            IRepository<Country> countryRepository
        )
        {
            _genreRepository = genreRepository;
            _languageRepository = languageRepository;
            _countryRepository = countryRepository;
        }

        public async Task<Genre?> GetGenreAsync(int id)
        {
            return await _genreRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _genreRepository.AddAsync(genre);
            await _genreRepository.SaveAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _genreRepository.Update(genre);
            await _genreRepository.SaveAsync();
        }

        public async Task RemoveGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetAsync(id);
            if (genre != null)
            {
                _genreRepository.Remove(genre);
                await _genreRepository.SaveAsync();
            }
        }

        public async Task<Language?> GetLanguageAsync(int id)
        {
            return await _languageRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Language>> GetAllLanguageAsync()
        {
            return await _languageRepository.GetAllAsync();
        }

        public async Task AddLanguageAsync(Language language)
        {
            await _languageRepository.AddAsync(language);
            await _languageRepository.SaveAsync();
        }

        public async Task UpdateLanguageAsync(Language language)
        {
            _languageRepository.Update(language);
            await _languageRepository.SaveAsync();
        }

        public async Task RemoveLanguageByIdAsync(int id)
        {
            var language = await _languageRepository.GetAsync(id);
            if (language != null)
            {
                _languageRepository.Remove(language);
                await _languageRepository.SaveAsync();
            }
        }

        public async Task<Country?> GetCountryAsync(int id)
        {
            return await _countryRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Country>> GetAllCountryAsync()
        {
            return await _countryRepository.GetAllAsync();
        }

        public async Task AddCountryAsync(Country country)
        {
            await _countryRepository.AddAsync(country);
            await _countryRepository.SaveAsync();
        }

        public async Task UpdateCountryAsync(Country country)
        {
            _countryRepository.Update(country);
            await _countryRepository.SaveAsync();
        }

        public async Task RemoveCountryByIdAsync(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country != null)
            {
                _countryRepository.Remove(country);
                await _countryRepository.SaveAsync();
            }
        }
    }
}
