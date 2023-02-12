using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Domain.Interfaces.Account
{
    public interface IUserRepository
    {
        Task<bool> ChekUserExistsByEmailAsync(string email);
        Task<bool> ChekUserExistsByUserNameAsync(string userName);
    }
}
