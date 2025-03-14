using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BE_ProgettoSettimana4.Models;

[Table("VERBALE")]
public partial class Verbale
{
    [Key]
    [Column("idverbale")]
    public Guid Idverbale { get; set; } = Guid.NewGuid();

    [Column("idanagrafica")]
    public Guid? Idanagrafica { get; set; }

    [Column("idviolazione")]
    public Guid? Idviolazione { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataViolazione { get; set; }

    [StringLength(100)]
    public string IndirizzoViolazione { get; set; } = null!;

    [Column("Nominativo_Agente")]
    [StringLength(50)]
    public string NominativoAgente { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataTrascrizioneVerbale { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal Importo { get; set; }

    public int? DecurtamentoPunti { get; set; }

    [ForeignKey("Idanagrafica")]
    [InverseProperty("Verbali")]
    public virtual Anagrafica? Anagrafica { get; set; }

    [ForeignKey("Idviolazione")]
    [InverseProperty("Verbali")]
    public virtual TipoViolazione? TipoViolazione { get; set; }
}
