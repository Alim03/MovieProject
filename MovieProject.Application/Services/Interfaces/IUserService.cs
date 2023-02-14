using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Enums;
using MovieProject.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResult> RegisterUser(User user);
        Task<LoginUserResult> LoginUser(LoginUserViewModel user);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<User?> GetUserByEmailAsync(string email);


    }
}
