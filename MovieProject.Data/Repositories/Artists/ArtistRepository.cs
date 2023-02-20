using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data.Context;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Interfaces.Artists;

namespace MovieProject.Data.Repositories.Artists
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MovieProjectDbContext context) : base(context) { }

        public override void Update(Artist artist)
        {
            var artistInDb = GetArtistEagerLoad(artist.Id);
            if (artistInDb != null)
            {
                artistInDb.Name = artist.Name;
                artistInDb.Bio = artist.Bio;
                artistInDb.Image = artist.Image;
                artistInDb.BirthDate = artist.BirthDate;
                artistInDb.Careers.Clear();
                foreach (var career in artist.Careers)
                {
                    artistInDb.Careers.Add(career);
                }
            }
        }

        public async Task<Artist?> GetArtistEagerLoadAsync(int id)
        {
            return await Context.Artists
                .Include(a => a.Careers)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Artist? GetArtistEagerLoad(int id)
        {
            return  Context.Artists.Include(a => a.Careers).SingleOrDefault(a => a.Id == id);
        }
    }
}
