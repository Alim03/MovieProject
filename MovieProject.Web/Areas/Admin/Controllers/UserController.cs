using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Services.Implementations;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Application.Utilities;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.Entities.Movie;
using MovieProject.Domain.ViewModels.Account;
using MovieProject.Domain.ViewModels.Movie;

namespace MovieProject.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private protected IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                if (users == null)
                {
                    return NotFound();
                }
                var usersResult = _mapper.Map<
            IEnumerable<User>,
            IEnumerable<UsersListViewModel>
            >(users);
                return View(usersResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.RemoveUserByIdAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            var userResult = _mapper.Map<
              User,
             UsersListViewModel
             >(user);
            return View(userResult);
        }

        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(model.Id);
                if(user !=null)
                {
                    user.Email = model.Email;
                    user.Username = model.Username;
                    user.IsAdmin = model.IsAdmin;
                    user.IsActive   = model.IsActive;
                   await _userService.UpdateUser(user);
                    return RedirectToAction("Index");

                }
                return NotFound(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
