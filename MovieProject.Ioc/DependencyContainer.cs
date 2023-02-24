using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Application.Security.PasswordHelper;
using MovieProject.Application.Services.Implementations;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Data.Repositories;
using MovieProject.Data.Repositories.Account;
using MovieProject.Data.Repositories.Artists;
using MovieProject.Data.Repositories.Movies;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Account;
using MovieProject.Domain.Interfaces.Artists;
using MovieProject.Domain.Interfaces.Movies;

namespace MovieProject.Ioc
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArtistRepository,ArtistRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IArtistService,ArtistService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

        }
    }
}
