using JeuDontOnEstLeHerosNG.Infra.Database;
using JeuDontOnEstLeHerosNG.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JeuDontOnEstLeHerosNG.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AventureDataContext context;

    public HomeController(ILogger<HomeController> logger, AventureDataContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        context.Database.Migrate();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}