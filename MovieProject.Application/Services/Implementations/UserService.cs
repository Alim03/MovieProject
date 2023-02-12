using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserService(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
      
        public async Task<bool> RegisterUser(User user)
        {
            if (user != null)
            {
                var userExistsByEmail = await _userRepository.ChekUserExistsByEmailAsync(user.Email);
                if (!userExistsByEmail)
                {
                    return false;
                }
                var userExistsByUserName = await _userRepository.ChekUserExistsByUserNameAsync(user.Username);
                if (!userExistsByUserName)
                {
                    return false;
                }
                await _repository.AddAsync(user);
                await _repository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
