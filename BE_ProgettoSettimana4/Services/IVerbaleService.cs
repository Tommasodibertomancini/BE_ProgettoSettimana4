using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.Services
{
    public interface IVerbaleService
    {
        IEnumerable<Verbale> GetAll();
        Verbale GetById(Guid id);
        void Add(Verbale verbale);
        void Update(Verbale verbale);
        void Delete(Guid id);
    }
}
