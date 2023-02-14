using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Security.PasswordHelper;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.ViewModels.Account;

namespace MovieProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public AccountController(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser( RegisterUserViewModel request)
        {
            try
            {
                if (request != null)
                {
                    if (request.Password != request.ConfirmPassword)
                    {
                        return NotFound();
                    }
                    User newUser = new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        IsAdmin = false,
                        Password = _passwordHasher.EncodePasswordMd5(request.Password)
                    };
                    var user = await _userService.RegisterUser(newUser);
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserViewModel request)
        {
            try
            {
                if(request != null)
                {
                var result = await _userService.LoginUser(request);
                    switch (result)
                    {
                        case Domain.Enums.LoginUserResult.WrongPassword:
                            break; 
                        case Domain.Enums.LoginUserResult.NotFound:
                            break;
                        case Domain.Enums.LoginUserResult.Success:
                            return View();
                            break;// Claim TODO
                        default:
                            break;
                    }
                    return View();
                }
                return View();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
