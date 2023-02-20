using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Services.Interfaces;

namespace MovieProject.Web.HttpHandler
{
   
        public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
        {
            private IUserService _userService;


            public void OnAuthorization(AuthorizationFilterContext context)
            
        {

                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    var userId = context.HttpContext.User.GetUserId();
                    _userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

                    if (!_userService.ChekUserIsAdmin(userId))
                    {
                        context.Result = new RedirectResult("/mmd");
                    }
                }
                else
                {
                    context.Result = new RedirectResult("/abbas");
                }
            }
    }
}
