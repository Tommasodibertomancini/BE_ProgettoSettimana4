using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BE_ProgettoSettimana4.Models;

[Table("TIPO_VIOLAZIONE")]
public partial class TipoViolazione
{
    [Key]
    [Column("idviolazione")]
    public Guid Idviolazione { get; set; } = Guid.NewGuid();

    [Column("descrizione")]
    [StringLength(1500)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("TipoViolazione")]
    public virtual ICollection<Verbale> Verbali { get; set; } = new List<Verbale>();
}
