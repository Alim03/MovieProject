using Microsoft.EntityFrameworkCore;
using MovieProject.Data.Context;
using MovieProject.Domain.Interfaces.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        protected readonly MovieProjectDbContext _context;

        public UserRepository(MovieProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChekUserExistsByEmailAsync(string email)
        {
           return await _context.Users.AnyAsync(a => a.Email == email);
        }

        public async Task<bool> ChekUserExistsByUserNameAsync(string userName)
        {
            return await _context.Users.AnyAsync(a => a.Username == userName);
        }
    }
}
