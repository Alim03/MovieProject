using MovieProject.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.Interfaces.Account
{
    public interface IUserRepository :IRepository<User>
    {
        Task<bool> ChekUserExistsByEmailAsync(string email);
        Task<bool> ChekUserExistsByUserNameAsync(string userName);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailOrUserNameAsync(string input);
        bool ChekUserIsAdmin(int userId);



    }
}
