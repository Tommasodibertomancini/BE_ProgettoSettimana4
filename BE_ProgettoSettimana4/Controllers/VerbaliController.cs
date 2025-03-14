using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Services;
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
        var verbali = _verbaleService.GetAll();
        ViewBag.Verbali = verbali;
        return View();
    }

    public IActionResult Create()
    {
        ViewBag.Anagrafiche = new SelectList(_anagraficaService.GetAll(), "Idanagrafica", "Cognome");
        ViewBag.TipoViolazioni = new SelectList(_violazioneService.GetAll(), "Idviolazione", "Descrizione");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Verbale verbale)
    {
        if (ModelState.IsValid)
        {
            verbale.Idverbale = Guid.NewGuid();
            _verbaleService.Add(verbale);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Anagrafiche = new SelectList(_anagraficaService.GetAll(), "Idanagrafica", "Cognome", verbale.Idanagrafica);
        ViewBag.TipoViolazioni = new SelectList(_violazioneService.GetAll(), "Idviolazione", "Descrizione", verbale.Idviolazione);
        return View(verbale);
    }
}
