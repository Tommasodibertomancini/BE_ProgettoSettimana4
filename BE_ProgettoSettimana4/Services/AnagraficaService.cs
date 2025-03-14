using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.Services
{
    public class AnagraficaService : IAnagraficaService
    {
        private readonly GestioneSanzioniDbContext _context;

        public AnagraficaService(GestioneSanzioniDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Anagrafica> GetAll()
        {
            return _context.Anagrafiche.ToList();
        }

        public Anagrafica GetById(Guid id)
        {
            return _context.Anagrafiche.Find(id);
        }

        public void Add(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Add(anagrafica);
            _context.SaveChanges();
        }

        public void Update(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Update(anagrafica);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var anagrafica = _context.Anagrafiche.Find(id);
            if (anagrafica != null)
            {
                _context.Anagrafiche.Remove(anagrafica);
                _context.SaveChanges();
            }
        }
    }

}
