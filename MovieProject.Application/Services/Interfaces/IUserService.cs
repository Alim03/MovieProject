using MovieProject.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);

    }
}
