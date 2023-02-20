using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.ViewModels.Movie;

namespace MovieProject.Web.Areas.Admin.Controllers
{
    public class CareerController : AdminBaseController
    {
        private protected IArtistService _artistService;

        public CareerController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public async Task<IActionResult> Index()
        {
            var allCareer = await _artistService.GetAllCareerAsync();
            return View(allCareer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInfoViewModel careerViewModel)
        {
            if (ModelState.IsValid)
            {
                var career = new Career() { Title = careerViewModel.title };
                await _artistService.AddCareerAsync(career);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var career = await _artistService.GetCareerAsync(id);
            if (career == null)
            {
                return RedirectToAction("Index");
            }
            var careerViewModel = new EditInfoViewModel() { title = career.Title };
            return View(careerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInfoViewModel careerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(careerViewModel);
            }
            var career = new Career() { Id = careerViewModel.Id, Title = careerViewModel.title };
            await _artistService.UpdateCareerAsync(career);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.RemoveCareerByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
