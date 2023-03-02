using MovieProject.Domain.Entities.Artists;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Artist;
using MovieProject.Domain.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.ViewModels.Account;

namespace MovieProject.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UsersListViewModel>();
        }
    }
}
