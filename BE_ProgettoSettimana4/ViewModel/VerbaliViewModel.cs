using Microsoft.AspNetCore.Mvc.Rendering;
using BE_ProgettoSettimana4.Models;

namespace BE_ProgettoSettimana4.ViewModels
{
    public class VerbaliViewModel
    {
        public List<Verbale> Verbali { get; set; }
        public SelectList Anagrafiche { get; set; }
        public SelectList TipoViolazioni { get; set; }
        public Verbale Verbale { get; set; }
    }
}
