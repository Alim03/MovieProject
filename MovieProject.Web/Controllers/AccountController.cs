using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Security.PasswordHelper;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
using MovieProject.Domain.ViewModels.Account;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using MovieProject.Domain.ViewModels.Common;
using MovieProject.Web.HttpHandler;

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
        public async Task<IActionResult> Account()
        {
            try
            {
                var userEmail = HttpContext.User.GetUserEmail();
                if (userEmail == null)
                {
                    return View();
                }
                var user = await _userService.GetUserByEmailAsync(userEmail);
                UserProfileViewModel userProfile = new UserProfileViewModel
                {
                    Email = user.Email,
                    UserName = user.Username
                };
                var userProfileViewModel = new LoginUserResponseViewModel()
                {
                    userProfileViewModel = userProfile
                };
                return View(userProfileViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Account", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel request)
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
        [HttpGet]
        [PermissionChecker]
        public IActionResult Index()
        {
            var aaa = HttpContext.User.GetUserEmail();
            return View(aaa);
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserViewModel request)
        {
            try
            {

                if (request != null)
                {
                    var result = await _userService.LoginUser(request);
                    
                    switch (result)
                    {
                        case Domain.Enums.LoginUserResult.WrongPassword:
                            var responseViewModel = new ResponseViewModel { IsSuccessFull = false, Message = ErrorsMessages.UserNotfound };
                            //responseViewModel.ResponseViewModel = result2;
                            var loginUserResponseViewModel = new LoginUserResponseViewModel() { ResponseViewModel= responseViewModel };
                            //responseViewModel.LoginUserViewModel=
                            return View("Account", loginUserResponseViewModel);
                        case Domain.Enums.LoginUserResult.NotFound:
                        case Domain.Enums.LoginUserResult.Success:
                            var user = await _userService.GetUserByEmailOrUserNameAsync(request.Input);
                            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,user.Email),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                        };

                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            var properties = new AuthenticationProperties
                            {
                                IsPersistent = true
                            };
                            HttpContext.SignInAsync(principal, properties);
                            return RedirectToAction("index", "home");
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


        [HttpGet]
        public IActionResult LoginUser()
        {
            return RedirectToAction("Account","Account");
        }

    }
}
