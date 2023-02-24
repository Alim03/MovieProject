using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Dtos.Movie;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Movie;

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

        Task<List<Movie>> GetMovieByTittle(string searchKey);
        Task<Movie?> GetMovieAsync(int id);
        Task<Movie?> GetMovieEagerLoadAsync(int id);
        Task<IEnumerable<Movie?>> GetAllMoviesAsync();
        Task AddMovieAsync(Movie movie);
        Task UpdaeMovieAsync(Movie movie);
        Task<IEnumerable<Language>> GetMovieLanguageAsync(int[] selectedIds);
        Task<IEnumerable<Country>> GetMoviesCountryAsync(int[] selectedIds);
        Task<IEnumerable<Genre>> GetMovieGenreAsync(int[] selectedIds);
        Task<IEnumerable<Artist>> GetMovieArtistAsync(int[] selectedIds);
        Task<AddMovieViewModel> GetAllMovieSelectedListAsync();
        Task RemoveMovieByIdAsync(int id);
        int[] SelectArtistIds(ICollection<Artist> artists);
        int[] SelectGenreIds(ICollection<Genre> genres);
        int[] SelectLanguageIds(ICollection<Language> languages);
        int[] SelectCountryIds(ICollection<Country> countries);

    }
}
