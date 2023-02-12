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
        Task RemoveGenreByIdAsync(int id);
        Task<Country?> GetCountryAsync(int id);
        Task<IEnumerable<Country>> GetAllCountryAsync();
        Task AddCountryAsync(Country country);
        Task UpdateCountryAsync(Country country);
        Task RemoveCountryByIdAsync(int id);
        Task<Language?> GetLanguageAsync(int id);
        Task<IEnumerable<Language>> GetAllLanguageAsync();
        Task AddLanguageAsync(Language language);
        Task UpdateLanguageAsync(Language language);
        Task RemoveLanguageByIdAsync(int id);
    }
}
