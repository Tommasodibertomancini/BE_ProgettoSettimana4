using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.Services
{
    public interface IAnagraficaService
    {
        IEnumerable<Anagrafica> GetAll();
        Anagrafica GetById(Guid id);
        void Add(Anagrafica anagrafica);
        void Update(Anagrafica anagrafica);
        void Delete(Guid id);
    }
}
