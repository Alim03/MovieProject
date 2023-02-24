using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Application.Utilities;
using MovieProject.Data.Repositories;
using MovieProject.Domain.Dtos.Movie;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Movies;
using MovieProject.Domain.ViewModels.Movie;

namespace MovieProject.Application.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Country> _countryRepository;
        private protected IRepository<Career> _careerRepository;
        private protected IRepository<Artist> _artistRepository;

        private readonly IMovieRepository _movieRepository;

        public MovieService(
            IRepository<Genre> genreRepository,
            IRepository<Language> languageRepository,
            IRepository<Country> countryRepository,
            IMovieRepository movieRepository
            ,
            IRepository<Career> careerRepository,
           IRepository<Artist> artistRepository   

        )
        {
            _genreRepository = genreRepository;
            _languageRepository = languageRepository;
            _countryRepository = countryRepository;
            _movieRepository = movieRepository;
            _careerRepository = careerRepository;
            _artistRepository = artistRepository;
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
        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveAsync();
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


        public int[] SelectArtistIds(ICollection<Artist> artists)
        {
            return artists.Select(x => x.Id).ToArray();
        }
        public int[] SelectGenreIds(ICollection<Genre> genres)
        {
            return genres.Select(x => x.Id).ToArray();
        }
        public int[] SelectLanguageIds(ICollection<Language> languages)
        {
            return languages.Select(x => x.Id).ToArray();
        }
        public int[] SelectCountryIds(ICollection<Country> countries)
        {
            return countries.Select(x => x.Id).ToArray();
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

        public Task<List<Movie>> GetMovieByTittle(string searchKey)
        {
            return _movieRepository.GetMovieByTittle(searchKey);
        }

        public async Task<IEnumerable<Career>> WhereCareerContainsAsync(int[] selectedCareerIds)
        {
            var careers = await _careerRepository.GetAllAsync();
            return careers.Where(c => selectedCareerIds.Contains(c.Id));
        }

        public async Task<MovieDetailsDto> MovieDetailsAsync(int[] selectedIds)
        {
            var careers = await _careerRepository.GetAllAsync();
            var genre = await _genreRepository.GetAllAsync();
            var artist = await _artistRepository.GetAllAsync();
            var countrys = await _countryRepository.GetAllAsync();
            var languages = await _languageRepository.GetAllAsync();

            MovieDetailsDto detailsDto = new MovieDetailsDto()
            {
                Careers = careers.Where(c => selectedIds.Contains(c.Id)),
                Genres = genre.Where(c => selectedIds.Contains(c.Id)),
                Artists = artist.Where(c => selectedIds.Contains(c.Id)),
                Countrys = countrys.Where(c => selectedIds.Contains(c.Id)),
                languages = languages.Where(c => selectedIds.Contains(c.Id))
            };
            return detailsDto;

        }

        public Task<Movie?> GetMovieEagerLoadAsync(int id)
        {
           return _movieRepository.GetMovieEagerLoadAsync(id);
        }

        public async Task<IEnumerable<Movie?>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }
 

        public async Task<IEnumerable<Language>> GetMovieLanguageAsync(int[] selectedIds)
        {
            var Language = await _languageRepository.GetAllAsync();
            return Language.Where(c => selectedIds.Contains(c.Id));
        }

        public async Task<IEnumerable<Genre>> GetMovieGenreAsync(int[] selectedIds)
        {
            var Genre = await _genreRepository.GetAllAsync();
            return Genre.Where(c => selectedIds.Contains(c.Id));
        }

        public async Task<IEnumerable<Artist>> GetMovieArtistAsync(int[] selectedIds)
        {   
            var Artist = await _artistRepository.GetAllAsync();
            return Artist.Where(c => selectedIds.Contains(c.Id));
        }


        public async Task<IEnumerable<Country>> GetMoviesCountryAsync(int[] selectedIds)
        {
            var Country = await _countryRepository.GetAllAsync();
            return Country.Where(c => selectedIds.Contains(c.Id));
        }

        public async Task UpdaeMovieAsync(Movie movie)
        {
             _movieRepository.Update(movie);
            await _movieRepository.SaveAsync();
        }

        public async Task<AddMovieViewModel> GetAllMovieSelectedListAsync()
        {
            var genere = await _genreRepository.GetAllAsync();
            var lang = await _languageRepository.GetAllAsync();
            var country = await _countryRepository.GetAllAsync();
            var artist = await _artistRepository.GetAllAsync();
            var careers = await _careerRepository.GetAllAsync();

            AddMovieViewModel model = new AddMovieViewModel
            {
                Artists = artist.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name }),
                Country = country.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.title }),
                Genre = genere.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.title }),
                Languages = lang.Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.title })
            };
            return model;
        }

        public async Task RemoveMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie != null)
            {
                if (movie.Image != null)
                {
                    FileHandler.DeleteImage(movie.Image);
                }
                _movieRepository.Remove(movie);
                await _artistRepository.SaveAsync();
            }
        }

        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _movieRepository.GetAsync(id);

        }
    }
}
