using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.Services
{
    public interface IViolazioneService
    {
        IEnumerable<TipoViolazione> GetAll();
        TipoViolazione GetById(Guid id);
        void Add(TipoViolazione violazione);
        void Update(TipoViolazione violazione);
        void Delete(Guid id);
    }
}
