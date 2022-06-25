using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ES2TP.Models;

namespace ES2TP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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

    public IActionResult Login()
    {
        return RedirectToAction(controllerName: "Auth", actionName: "Login");
    }

    public IActionResult Registo()
    {
        return RedirectToAction(controllerName: "RegistUser1", actionName: "RegistUser");
    }
}