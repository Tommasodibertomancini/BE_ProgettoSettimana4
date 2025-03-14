using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Models;
using BE_ProgettoSettimana4.Services;
using BE_ProgettoSettimana4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AnagraficheController : Controller
{
    private readonly IAnagraficaService _anagraficaService;

    public AnagraficheController(IAnagraficaService anagraficaService)
    {
        _anagraficaService = anagraficaService;
    }

    public IActionResult Index()
    {
        var viewModel = new AnagraficheViewModel
        {
            Anagrafiche = _anagraficaService.GetAll().ToList()
        };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Anagrafica anagrafica)
    {
        if (ModelState.IsValid)
        {
            anagrafica.Idanagrafica = Guid.NewGuid(); 
            _anagraficaService.Add(anagrafica);
            return RedirectToAction(nameof(Index));
        }
        return View(anagrafica);
    }
}