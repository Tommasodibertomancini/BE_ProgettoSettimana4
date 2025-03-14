using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BE_ProgettoSettimana4.Models;

[Table("ANAGRAFICA")]
[Index("CodFisc", Name = "UQ__ANAGRAFI__063721E1F3FDD5A7", IsUnique = true)]
public partial class Anagrafica
{
    [Key]
    [Column("idanagrafica")]
    public Guid Idanagrafica { get; set; } = Guid.NewGuid();

    [StringLength(50)]
    [Unicode(false)]
    public string Cognome { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Città { get; set; } = null!;

    [Column("CAP")]
    [StringLength(5)]
    [Unicode(false)]
    public string Cap { get; set; } = null!;

    [Column("Cod_Fisc")]
    [StringLength(17)]
    [Unicode(false)]
    public string CodFisc { get; set; } = null!;

    [InverseProperty("Anagrafica")]
    public virtual ICollection<Verbale> Verbali { get; set; } = new List<Verbale>();
}
