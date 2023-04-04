using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.services;

namespace Biblioteca_Virtual.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBibliService _pokeService;
    public HomeController(ILogger<HomeController> logger, IBibliService pokeService)
    {
        _logger = logger;
        _pokeService = pokeService;
    }
    public IActionResult Index(string tipo)
    {
        var pokes = _pokeService.GetBibliotecaDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(pokes);
    }
    public IActionResult Details(int Numero)
    {
        var pokemon = _pokeService.GetDetailedLivro(Numero);
        return View(pokemon);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier
        });
    }
}
