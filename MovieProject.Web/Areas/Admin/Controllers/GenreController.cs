using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Movie;

namespace MovieProject.Web.Areas.Admin.Controllers
{
    public class GenreController : AdminBaseController
    {
        private readonly IMovieService _movieService;

        public GenreController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var allGenre = await _movieService.GetAllGenreAsync();
            return View(allGenre);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInfoViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre() { title = genreViewModel.title };
                await _movieService.AddGenreAsync(genre);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _movieService.GetGenreAsync(id);
            if (genre == null)
            {
                return RedirectToAction("Index");
            }
            var genreViewModel = new EditInfoViewModel() { title = genre.title };
            return View(genreViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInfoViewModel genreViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(genreViewModel);
            }
            var genre = new Genre() { Id = genreViewModel.Id, title = genreViewModel.title };
            await _movieService.UpdateGenreAsync(genre);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.RemoveGenreByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
