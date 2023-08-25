using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TerminatorGYM.Models;

public partial class TerminatorGymContext : DbContext
{
    public TerminatorGymContext()
    {
    }

    public TerminatorGymContext(DbContextOptions<TerminatorGymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Membresia> Membresias { get; set; }

    public virtual DbSet<Miembro> Miembros { get; set; }

    public virtual DbSet<MiembrosEvento> MiembrosEventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ContactoId).HasName("PK_ContactoID");

            entity.ToTable("Contacto");

            entity.Property(e => e.ContactoId).HasColumnName("ContactoID");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");

            entity.HasOne(d => d.Miembro).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Miembros_MiembroID");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK_EventoID");

            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaEvento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Evento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Membresia>(entity =>
        {
            entity.HasKey(e => e.MembresiaId).HasName("PK_MembresiaID");

            entity.Property(e => e.MembresiaId).HasColumnName("MembresiaID");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.Precio).HasColumnType("smallmoney");
            entity.Property(e => e.TipoMembresia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Tipo_Membresia");

            entity.HasOne(d => d.Miembro).WithMany(p => p.Membresia)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_M_Miembros_MiembroID");
        });

        modelBuilder.Entity<Miembro>(entity =>
        {
            entity.HasKey(e => e.MiembroId).HasName("PK_MiembroID");

            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MiembrosEvento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Miembros_Eventos");

            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");

            entity.HasOne(d => d.Evento).WithMany()
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ME_Eventos_EventoID");

            entity.HasOne(d => d.Miembro).WithMany()
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ME_Miembros_MiembroID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
