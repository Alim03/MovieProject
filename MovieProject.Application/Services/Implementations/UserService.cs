using MovieProject.Application.Security.PasswordHelper;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.Enums;
using MovieProject.Domain.Interfaces;
using MovieProject.Domain.Interfaces.Account;
using MovieProject.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User?> GetUserByEmailOrUserNameAsync(string input)
        {
            return await _userRepository.GetUserByEmailOrUserNameAsync(input);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _userRepository.GetUserByUserNameAsync(userName);
        }

        public async Task<LoginUserResult> LoginUser(LoginUserViewModel user)
        {
            var getUserByEmail = await _userRepository.GetUserByEmailAsync(user.Input);
            if (getUserByEmail == null)
            {
                var getUserByUserName = await _userRepository.GetUserByUserNameAsync(user.Input);
                if (getUserByUserName == null)
                {
                    return LoginUserResult.NotFound;
                }
                if (getUserByUserName.Password != _passwordHasher.EncodePasswordMd5(user.Password))
                {
                    return LoginUserResult.WrongPassword;
                }
                return LoginUserResult.Success;
            }
            if (getUserByEmail.Password != _passwordHasher.EncodePasswordMd5(user.Password))
            {
                return LoginUserResult.WrongPassword;
            }
            return LoginUserResult.Success;
        }

        public async Task<RegisterUserResult> RegisterUser(User user)
        {
            var userExistsByEmail = await _userRepository.ChekUserExistsByEmailAsync(user.Email);
            if (userExistsByEmail)
            {
                return RegisterUserResult.EmailExist;
            }
            var userExistsByUserName = await _userRepository.ChekUserExistsByUserNameAsync(user.Username);
            if (userExistsByUserName)
            {
                return RegisterUserResult.UserNameExist;
            }
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
            return RegisterUserResult.Success;
        }

        public async Task RemoveUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
            }

        }

        public async Task UpdateUser(User user) 
        {

            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }

        bool IUserService.ChekUserIsAdmin(int userId)
        {
            return _userRepository.ChekUserIsAdmin(userId);
        }
    }
}
