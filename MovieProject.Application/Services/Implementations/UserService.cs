﻿using MovieProject.Application.Security.PasswordHelper;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
          return  await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _userRepository.GetUserByUserNameAsync(userName);
        }

        public async Task<LoginUserResult> LoginUser(LoginUserViewModel user)
        {
            var getUserByEmail = await _userRepository.GetUserByEmailAsync(user.Email);
            if (getUserByEmail == null)
            {
                var getUserByUserName = await _userRepository.GetUserByUserNameAsync(user.Username);
                if (getUserByEmail == null)
                {
                    return LoginUserResult.NotFound;
                }
                if (_passwordHasher.EncodePasswordMd5(getUserByEmail.Password) != _passwordHasher.EncodePasswordMd5(user.Password))
                {
                    return LoginUserResult.WrongPassword;
                }
                return LoginUserResult.Success;
            }
           if(_passwordHasher.EncodePasswordMd5(getUserByEmail.Password) != _passwordHasher.EncodePasswordMd5(user.Password))
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
    }
}
