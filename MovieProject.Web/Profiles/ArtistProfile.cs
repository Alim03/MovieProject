using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.ViewModels.Artist;

namespace MovieProject.Web.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistListViewModel>();
        }
    }
}
