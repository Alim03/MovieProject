using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;
using MovieProject.WebApi.Dtos;

namespace MovieProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request)
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
                        Password = request.Password
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
    }
}
