using Microsoft.EntityFrameworkCore;
using MovieProject.Data.Context;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories.Account
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieProjectDbContext context) : base(context)
        {
        }

        public async Task<bool> ChekUserExistsByEmailAsync(string email)
        {

            return await Context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ChekUserExistsByUserNameAsync(string userName)
        {
            return await Context.Users.AnyAsync(u => u.Username == userName);
        }

        public bool ChekUserIsAdmin(int userId)
        {
            var user =  Context.Users.FirstOrDefault(p => p.Id == userId);
            if (user.IsAdmin)
            {
                return true;
            }
            return false;

        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
           return await Context.Users.FirstOrDefaultAsync(u=> u.Email == email);
        }

        public async Task<User?> GetUserByEmailOrUserNameAsync(string input)
        {
            return await Context.Users.Where(p=>p.Username== input || p.Email == input).FirstOrDefaultAsync();
        }

        public  async Task<User?> GetUserByIdAsync(int id)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == userName);
        }
    }
}
