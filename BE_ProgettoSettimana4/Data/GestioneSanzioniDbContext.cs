using System;
using System.Collections.Generic;
using BE_ProgettoSettimana4.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_ProgettoSettimana4.Data;

public partial class GestioneSanzioniDbContext : DbContext
{
    public GestioneSanzioniDbContext()
    {
    }

    public GestioneSanzioniDbContext(DbContextOptions<GestioneSanzioniDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagrafiche { get; set; }

    public virtual DbSet<TipoViolazione> TipoViolazioni { get; set; }

    public virtual DbSet<Verbale> Verbali { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-GF8E309P\\SQLEXPRESS;Database=GestioneSanzioni;User Id=sa;Password=sa;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.Idanagrafica).HasName("PK__ANAGRAFI__7AB1023CFF2B6072");

            entity.Property(e => e.Idanagrafica).ValueGeneratedNever();
            entity.Property(e => e.Cap).IsFixedLength();
            entity.Property(e => e.CodFisc).IsFixedLength();
        });

        modelBuilder.Entity<TipoViolazione>(entity =>
        {
            entity.HasKey(e => e.Idviolazione).HasName("PK__TIPO_VIO__AF77BD92E920A61A");

            entity.Property(e => e.Idviolazione).ValueGeneratedNever();
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.Idverbale).HasName("PK__VERBALE__073D2A452C7C0720");

            entity.Property(e => e.Idverbale).ValueGeneratedNever();

            entity.HasOne(d => d.Anagrafica).WithMany(p => p.Verbali).HasConstraintName("FK__VERBALE__idanagr__5070F446");

            entity.HasOne(d => d.TipoViolazione).WithMany(p => p.Verbali).HasConstraintName("FK__VERBALE__idviola__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
