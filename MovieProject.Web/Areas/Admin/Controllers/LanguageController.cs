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
    public class LanguageController : AdminBaseController
    {
        private protected IMovieService _movieService;

        public LanguageController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var allLanguage = await _movieService.GetAllLanguageAsync();
            return View(allLanguage);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInfoViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                var language = new Language() { title = languageViewModel.title };
                await _movieService.AddLanguageAsync(language);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var language = await _movieService.GetLanguageAsync(id);
            if (language == null)
            {
                return RedirectToAction("Index");
            }
            var languageViewModel = new EditInfoViewModel() { title = language.title };
            return View(languageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInfoViewModel languageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(languageViewModel);
            }
            var language = new Language()
            {
                Id = languageViewModel.Id,
                title = languageViewModel.title
            };
            await _movieService.UpdateLanguageAsync(language);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.RemoveLanguageByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
