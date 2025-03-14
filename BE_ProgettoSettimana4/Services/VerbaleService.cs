using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BE_ProgettoSettimana4.Models;
using BE_ProgettoSettimana4.Data;

namespace BE_ProgettoSettimana4.Services
{
    public class VerbaleService : IVerbaleService
    {
        private readonly GestioneSanzioniDbContext _context;

        public VerbaleService(GestioneSanzioniDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Verbale> GetAll()
        {
            return _context.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .ToList();
        }

        public Verbale GetById(Guid id)
        {
            return _context.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .FirstOrDefault(v => v.Idverbale == id);
        }

        public void Add(Verbale verbale)
        {
            _context.Verbali.Add(verbale);
            _context.SaveChanges();
        }

        public void Update(Verbale verbale)
        {
            _context.Verbali.Update(verbale);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var verbale = _context.Verbali.Find(id);
            if (verbale != null)
            {
                _context.Verbali.Remove(verbale);
                _context.SaveChanges();
            }
        }
    }



}
