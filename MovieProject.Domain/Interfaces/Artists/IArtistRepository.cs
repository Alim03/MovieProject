using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieProject.Domain.Entities.Artists;

namespace MovieProject.Domain.Interfaces.Artists
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist?> GetArtistEagerLoadAsync(int id);
    }
}
