using System.Diagnostics;
using LudumDare50.Web.Clients;
using Microsoft.AspNetCore.Mvc;
using LudumDare50.Web.Models;

namespace LudumDare50.Web.Controllers;

public class HomeController : Controller
{
    private readonly StatsClient _statsClient;

    public HomeController(StatsClient statsClient)
    {
        _statsClient = statsClient;
    }

    public async Task<IActionResult> Index()
    {
        return View(new HomeViewModel
        {
            StatsList = await _statsClient.GetAll()
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}