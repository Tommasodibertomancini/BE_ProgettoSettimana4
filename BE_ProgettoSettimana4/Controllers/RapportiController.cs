using BE_ProgettoSettimana4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using BE_ProgettoSettimana4.ViewModels;
using BE_ProgettoSettimana4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class RapportiController : Controller
{
    private readonly GestioneSanzioniDbContext _context;

    public RapportiController(GestioneSanzioniDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TotaleVerbaliPerTrasgressore()
    {
        var report = _context.Verbali
            .Include(v => v.Anagrafica)
            .GroupBy(v => v.Anagrafica)
            .Select(g => new
            {
                Trasgressore = g.Key,
                TotaleVerbali = g.Count()
            })
            .ToList()
            .Select(item => (dynamic)item)
            .ToList();

        var viewModel = new RapportoViewModel
        {
            Titolo = "Totale Verbali per Trasgressore",
            Report = report
        };

        return View(viewModel);
    }


    public IActionResult TotalePuntiDecurtatiPerTrasgressore()
    {
        var report = _context.Verbali
            .Include(v => v.Anagrafica)
            .GroupBy(v => v.Anagrafica)
            .Select(g => new
            {
                Trasgressore = g.Key,
                TotalePunti = g.Sum(v => v.DecurtamentoPunti)
            })
            .ToList()
            .Select(item => (dynamic)item)
            .ToList();

        var viewModel = new RapportoViewModel
        {
            Titolo = "Totale Punti Decurtati per Trasgressore",
            Report = report
        };

        return View(viewModel);
    }


    public IActionResult ViolazioniSuperioriA10Punti()
    {
        var report = _context.Verbali
            .Include(v => v.Anagrafica)
            .Where(v => v.DecurtamentoPunti > 10)
            .Select(v => new
            {
                v.Importo,
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.DecurtamentoPunti
            })
            .ToList()
            .Select(item => (dynamic)item)
            .ToList();

        var viewModel = new RapportoViewModel
        {
            Titolo = "Violazioni con Decurtamento Punti > 10",
            Report = report
        };

        return View(viewModel);
    }


    public IActionResult ViolazioniCostose()
    {
        var report = _context.Verbali
            .Include(v => v.Anagrafica)
            .Where(v => v.Importo > 400)
            .Select(v => new
            {
                v.Importo,
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.DecurtamentoPunti
            })
            .ToList()
            .Select(item => (dynamic)item)
            .ToList();

        var viewModel = new RapportoViewModel
        {
            Titolo = "Violazioni con Importo > 400 Euro",
            Report = report
        };

        return View(viewModel);
    }


    public IActionResult ViolazioniContestabili()
    {
        var contestabili = _context.Verbali
            .Include(v => v.Anagrafica)
            .Include(v => v.TipoViolazione)
            .Where(v => v.Importo < 200 && v.DecurtamentoPunti < 5)
            .Select(v => new
            {
                v.Importo,
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.DecurtamentoPunti,
                v.TipoViolazione.Descrizione
            })
            .ToList()
            .Select(item => (dynamic)item)
            .ToList();

        var viewModel = new RapportoViewModel
        {
            Titolo = "Violazioni Contestabili",
            Report = contestabili
        };

        return View(viewModel);
    }

}