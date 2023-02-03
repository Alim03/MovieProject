using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Application.Services.Implementations;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Data.Repositories;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Interfaces;

namespace MovieProject.Ioc
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Genre>, Repository<Genre>>();
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
