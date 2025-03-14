using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Services;
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
        var anagrafiche = _anagraficaService.GetAll();
        ViewBag.Anagrafiche = anagrafiche;
        return View();
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
