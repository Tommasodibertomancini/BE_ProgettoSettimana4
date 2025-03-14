using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Models;
using BE_ProgettoSettimana4.Services;
using BE_ProgettoSettimana4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

public class VerbaliController : Controller
{
    private readonly IVerbaleService _verbaleService;
    private readonly IAnagraficaService _anagraficaService;
    private readonly IViolazioneService _violazioneService;
    

    public VerbaliController(IVerbaleService verbaleService, IAnagraficaService anagraficaService, IViolazioneService violazioneService)
    {
        _verbaleService = verbaleService;
        _anagraficaService = anagraficaService;
        _violazioneService = violazioneService;
      
    }

    public IActionResult Index()
    {
        var viewModel = new VerbaliViewModel
        {
            Verbali = _verbaleService.GetAll().ToList()
        };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        var viewModel = new VerbaliViewModel
        {
            Anagrafiche = new SelectList(_anagraficaService.GetAll(), "Idanagrafica", "Cognome"),
            TipoViolazioni = new SelectList(_violazioneService.GetAll(), "Idviolazione", "Descrizione")
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Verbale verbale)
    {
        if (ModelState.IsValid)
        {
            verbale.Idverbale = Guid.NewGuid(); 
            _verbaleService.Add(verbale);

            return RedirectToAction(nameof(Index));
        }

        var viewModel = new VerbaliViewModel
        {
            Verbale = verbale,
            Anagrafiche = new SelectList(_anagraficaService.GetAll(), "Idanagrafica", "Cognome", verbale.Idanagrafica),
            TipoViolazioni = new SelectList(_violazioneService.GetAll(), "Idviolazione", "Descrizione", verbale.Idviolazione)
        };
        return View(viewModel);
    }
}