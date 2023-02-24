using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Artist;
using MovieProject.Domain.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MovieProject.Web.Profiles
{
    public class MoveiProfile : Profile
    {
        public MoveiProfile()
        {
            CreateMap<Movie, MovieViewModel>();
        }
    }
}
