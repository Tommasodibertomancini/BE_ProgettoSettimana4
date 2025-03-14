using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Models;
using BE_ProgettoSettimana4.Services;
using BE_ProgettoSettimana4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TipoViolazioniController : Controller
{
    private readonly IViolazioneService _violazioneService;

    public TipoViolazioniController(IViolazioneService violazioneService)
    {
        _violazioneService = violazioneService;
    }

    public IActionResult Index()
    {
        var viewModel = new TipoViolazioniViewModel
        {
            Violazioni = _violazioneService.GetAll().ToList()
        };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TipoViolazione violazione)
    {
        if (ModelState.IsValid)
        {
            violazione.Idviolazione = Guid.NewGuid(); 
            _violazioneService.Add(violazione);
            return RedirectToAction(nameof(Index));
        }
        return View(violazione);
    }
}