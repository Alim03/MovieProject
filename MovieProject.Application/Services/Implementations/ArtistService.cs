using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Application.Utilities;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Artists;

namespace MovieProject.Application.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private protected IArtistRepository _artistRepository;
        private protected IRepository<Career> _careerRepository;

        public ArtistService(
            IRepository<Career> careerRepository,
            IArtistRepository artistRepository
        )
        {
            _artistRepository = artistRepository;
            _careerRepository = careerRepository;
        }

        public async Task<Artist?> GetArtistAsync(int id)
        {
            return await _artistRepository.GetAsync(id);
        }

        public async Task<Artist?> GetArtistEagerLoadAsync(int id)
        {
            return await _artistRepository.GetArtistEagerLoadAsync(id);
        }

        public async Task<IEnumerable<Artist>> GetAllArtistAsync()
        {
            return await _artistRepository.GetAllAsync();
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _artistRepository.AddAsync(artist);
            await _artistRepository.SaveAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            _artistRepository.Update(artist);
            await _artistRepository.SaveAsync();
        }

        public async Task RemoveArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetAsync(id);
            if (artist != null)
            {
                if (artist.Image != null)
                {
                    FileHandler.DeleteImage(artist.Image);
                }
                _artistRepository.Remove(artist);
                await _artistRepository.SaveAsync();
            }
        }

        public async Task<Career?> GetCareerAsync(int id)
        {
            return await _careerRepository.GetAsync(id);
        }

        public int[] SelectCareersIds(ICollection<Career> careers)
        {
            return careers.Select(x => x.Id).ToArray();
        }

        public async Task<IEnumerable<Career>> GetAllCareerAsync()
        {
            return await _careerRepository.GetAllAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllCareerSelectListItemAsync()
        {
            var careers = await _careerRepository.GetAllAsync();
            return careers.Select(
                item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Title }
            );
        }

        public async Task<IEnumerable<Career>> WhereCareerContainsAsync(int[] selectedCareerIds)
        {
            var careers = await _careerRepository.GetAllAsync();
            return careers.Where(c => selectedCareerIds.Contains(c.Id));
        }

        public async Task AddCareerAsync(Career career)
        {
            await _careerRepository.AddAsync(career);
            await _careerRepository.SaveAsync();
        }

        public async Task UpdateCareerAsync(Career career)
        {
            _careerRepository.Update(career);
            await _careerRepository.SaveAsync();
        }

        public async Task RemoveCareerByIdAsync(int id)
        {
            var career = await _careerRepository.GetAsync(id);
            if (career != null)
            {
                _careerRepository.Remove(career);
                await _careerRepository.SaveAsync();
            }
        }
    }
}
