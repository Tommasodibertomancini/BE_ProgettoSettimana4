using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.Services
{
    public class ViolazioneService : IViolazioneService
    {
        private readonly GestioneSanzioniDbContext _context;

        public ViolazioneService(GestioneSanzioniDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TipoViolazione> GetAll()
        {
            return _context.TipoViolazioni.ToList();
        }

        public TipoViolazione GetById(Guid id)
        {
            return _context.TipoViolazioni.Find(id);
        }

        public void Add(TipoViolazione violazione)
        {
            _context.TipoViolazioni.Add(violazione);
            _context.SaveChanges();
        }

        public void Update(TipoViolazione violazione)
        {
            _context.TipoViolazioni.Update(violazione);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var violazione = _context.TipoViolazioni.Find(id);
            if (violazione != null)
            {
                _context.TipoViolazioni.Remove(violazione);
                _context.SaveChanges();
            }
        }
    }

}
