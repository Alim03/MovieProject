using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Application.Utilities;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.ViewModels.Artist;

namespace MovieProject.Web.Areas.Admin.Controllers
{
    public class ArtistController : AdminBaseController
    {
        private protected IArtistService _artistService;
        private protected IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ArtistController(
            IArtistService artistService,
            IMapper mapper,
            IWebHostEnvironment env
        )
        {
            _artistService = artistService;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var artists = await _artistService.GetAllArtistAsync();
            var artistViewModel = _mapper.Map<
                IEnumerable<Artist>,
                IEnumerable<ArtistListViewModel>
            >(artists);
            return View(artistViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var career = await _artistService.GetAllCareerSelectListItemAsync();
            var artistViewModel = new AddArtistViewModel { Careers = career.ToList() };
            return View(artistViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddArtistViewModel artistViewModel)
        {
            if (ModelState.IsValid)
            {
                var careers = await _artistService.WhereCareerContainsAsync(
                    artistViewModel.SelectedCareerIds
                );
                string? imageName = null;
                if (artistViewModel.Image != null)
                {
                    imageName = await FileHandler.ImageUploadAsync(artistViewModel.Image);
                }

                var artist = new Artist
                {
                    Name = artistViewModel.Name,
                    Bio = artistViewModel.Bio,
                    BirthDate = artistViewModel.BirthDate ?? default,
                    Image = imageName,
                    Careers = careers.ToList()
                };

                await _artistService.AddArtistAsync(artist);
                return RedirectToAction("Index");
            }
            var career = await _artistService.GetAllCareerSelectListItemAsync();
            artistViewModel.Careers = career.ToList();
            return View(artistViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var artist = await _artistService.GetArtistEagerLoadAsync(id);
            if (artist == null)
            {
                return RedirectToAction("Index");
            }
            var careersIds = _artistService.SelectCareersIds(artist.Careers);
            var career = await _artistService.GetAllCareerSelectListItemAsync();

            var artistViewModel = new EditArtistViewModel
            {
                Name = artist.Name,
                Bio = artist.Bio,
                BirthDate = artist.BirthDate,
                SelectedCareerIds = careersIds,
                Careers = career.ToList(),
                ImageName = artist.Image
            };

            return View(artistViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArtistViewModel viewModel)
        {
            var careerSelectListItems = await _artistService.GetAllCareerSelectListItemAsync();

            var imageName = viewModel.Image?.FileName ?? viewModel.ImageName;
            if (!ModelState.IsValid)
            {
                viewModel.Careers = careerSelectListItems.ToList();
                viewModel.ImageName = imageName;
                return View(viewModel);
            }
            var careers = await _artistService.WhereCareerContainsAsync(
                viewModel.SelectedCareerIds
            );

            if (viewModel.Image != null)
            {
                if (viewModel.ImageName != null)
                {
                    FileHandler.DeleteImage(viewModel.ImageName);
                }
                imageName = await FileHandler.ImageUploadAsync(viewModel.Image);
            }

            var artist = new Artist
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Bio = viewModel.Bio,
                Image = imageName,
                BirthDate = viewModel.BirthDate ?? default,
                Careers = careers.ToList()
            };

            await _artistService.UpdateArtistAsync(artist);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.RemoveArtistByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
