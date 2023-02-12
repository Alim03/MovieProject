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
    public class CountryController : AdminBaseController
    {
        private readonly IMovieService _movieService;

        public CountryController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var allCountry = await _movieService.GetAllCountryAsync();
            return View(allCountry);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInfoViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                var country = new Country() { title = countryViewModel.title };
                await _movieService.AddCountryAsync(country);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _movieService.GetCountryAsync(id);
            if (country == null)
            {
                return RedirectToAction("Index");
            }
            var countryViewModel = new EditInfoViewModel() { title = country.title };
            return View(countryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInfoViewModel countryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(countryViewModel);
            }
            var country = new Country()
            {
                Id = countryViewModel.Id,
                title = countryViewModel.title
            };
            await _movieService.UpdateCountryAsync(country);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.RemoveCountryByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
