using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Services.Implementations;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Application.Utilities;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Artist;
using MovieProject.Domain.ViewModels.Movie;

namespace MovieProject.Web.Areas.Admin.Controllers
{
    public class MovieController : AdminBaseController
    {
        private readonly IMovieService _movieService;
        private protected IMapper _mapper;
        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie(string searchKey)
        {
            try
            {
                if (searchKey == null)
                {
                    return View("Error Null Inputs");
                }
                var movie = await _movieService.GetMovieByTittle(searchKey);
                if (movie == null)
                {
                    return NotFound("Movie Not Found ");
                }
                return View(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movie = await _movieService.GetAllMoviesAsync();
            var movieResult = _mapper.Map<
                IEnumerable<Movie>,
                IEnumerable<MovieViewModel>
            >(movie);
            return View(movieResult);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var movie = await _movieService.GetAllMovieSelectedListAsync();
            return View(movie);
        }

        [HttpPost]

        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var geners = await _movieService.GetMovieGenreAsync(
                    model.SelectedGenreIds
                );
                var artist = await _movieService.GetMovieArtistAsync(
                  model.SelectedArtistsIds
              );
                var country = await _movieService.GetMoviesCountryAsync(
                  model.SelectedCountryIds
                 );
                var lang = await _movieService.GetMovieLanguageAsync(
              model.SelectedLanguagesIds);


                string? imageName = null;
                if (model.Image != null)
                {
                    imageName = await FileHandler.ImageUploadAsync(model.Image);
                }

                var movie = new Movie
                {
                    Title = model.Title,
                    Cover = model.Cover,
                    ReleasedDate = model.ReleasedDate,
                    Image = imageName,
                    Summary = model.Summary,
                    Time = model.Time,
                    CreatedDate = model.CreatedDate,
                    Artists =artist.ToList(),
                    Countries = country.ToList(),
                    Genres = geners.ToList(),
                    Languages = lang.ToList(),
                };

                await _movieService.AddMovieAsync(movie);
                return RedirectToAction("Index");
            }
            //var career = await _movieService.GetAllCareerSelectListItemAsync();
            //artistViewModel.Careers = career.ToList();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.RemoveMovieByIdAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieEagerLoadAsync(id);
            if (movie == null)
            {
                return RedirectToAction("Index");
            }
            var genreIds = _movieService.SelectGenreIds(movie.Genres);
            var countryIds = _movieService.SelectCountryIds(movie.Countries);
            var languagesIds = _movieService.SelectLanguageIds(movie.Languages);
            var artistIds =  _movieService.SelectArtistIds(movie.Artists);
            var movieDetails = await _movieService.GetAllMovieSelectedListAsync();
            var movieViewModel = new EditMovieViewModel
            {
                Title = movie.Title,
                Summary = movie.Summary,
                CreatedDate = movie.CreatedDate,
                ReleasedDate = movie.ReleasedDate,
                Time = movie.Time,
                SelectedArtistsIds = artistIds,
                SelectedGenreIds = genreIds,
                SelectedCountryIds = countryIds,
                SelectedLanguagesIds = languagesIds,
                Artists = movieDetails.Artists.ToList(),
                Genre = movieDetails.Genre.ToList(),
                Languages = movieDetails.Languages.ToList(),
                Country = movieDetails.Country.ToList(),
                ImageName = movie.Image
            };
            return View(movieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel Model)
        {
            var MovieDetailsSelectListItems = await _movieService.GetAllMovieSelectedListAsync();

            var imageName = Model.Image?.FileName ?? Model.ImageName;
            if (!ModelState.IsValid)
            {
                Model.Artists = MovieDetailsSelectListItems.Artists.ToList();
                Model.Country = MovieDetailsSelectListItems.Country.ToList();
                Model.Languages = MovieDetailsSelectListItems.Languages.ToList();
                Model.Genre = MovieDetailsSelectListItems.Genre.ToList();
                Model.ImageName = imageName;
                return View(Model);
            }

            var geners = await _movieService.GetMovieGenreAsync(
                Model.SelectedGenreIds
            );
            var artist = await _movieService.GetMovieArtistAsync(
              Model.SelectedArtistsIds
          );
            var country = await _movieService.GetMoviesCountryAsync(
              Model.SelectedCountryIds
             );
            var lang = await _movieService.GetMovieLanguageAsync(
          Model.SelectedLanguagesIds);


            if (Model.Image != null)
            {
                if (Model.ImageName != null)
                {
                    FileHandler.DeleteImage(Model.ImageName);
                }
                imageName = await FileHandler.ImageUploadAsync(Model.Image);
            }

            var movie = new Movie
            {
                Id = Model.Id,
                Title = Model.Title,
                Summary = Model.Summary,
                Time = Model.Time,
                CreatedDate = Model.CreatedDate ?? default,
                ReleasedDate = Model.ReleasedDate ?? default,
                Image = imageName,
                Artists = artist.ToList(),
                Genres = geners.ToList(),
                Languages = lang.ToList(),
                Countries = country.ToList()
            };
            await _movieService.UpdaeMovieAsync(movie);
            return RedirectToAction("Index");
        }
    }
}
