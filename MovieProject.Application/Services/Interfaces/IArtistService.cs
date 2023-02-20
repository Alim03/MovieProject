using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieProject.Domain.Entities.Artists;

namespace MovieProject.Application.Services.Interfaces
{
    public interface IArtistService
    {
        Task<Artist?> GetArtistAsync(int id);
        Task<Artist?> GetArtistEagerLoadAsync(int id);
        Task<IEnumerable<Artist>> GetAllArtistAsync();
        Task AddArtistAsync(Artist career);
        Task UpdateArtistAsync(Artist artist);
        Task RemoveArtistByIdAsync(int id);
        Task<Career?> GetCareerAsync(int id);
        int[] SelectCareersIds(ICollection<Career> careers);
        Task<IEnumerable<Career>> GetAllCareerAsync();
        Task<IEnumerable<SelectListItem>> GetAllCareerSelectListItemAsync();
        Task<IEnumerable<Career>> WhereCareerContainsAsync(int[] selectedCareerIds);
        Task AddCareerAsync(Career career);
        Task UpdateCareerAsync(Career career);
        Task RemoveCareerByIdAsync(int id);
    }
}
