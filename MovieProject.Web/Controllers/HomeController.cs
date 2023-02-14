using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Application.Services.Interfaces;
using MovieProject.Domain.Entities.Account;

namespace MovieProject.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
