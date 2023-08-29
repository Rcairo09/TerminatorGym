using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Models;

public partial class GymAppContext : DbContext
{
    public GymAppContext()
    {
    }

    public GymAppContext(DbContextOptions<GymAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Entrenador> Entrenadors { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Membresium> Membresia { get; set; }

    public virtual DbSet<Miembro> Miembros { get; set; }

    public virtual DbSet<MiembroEvento> MiembroEventos { get; set; }

    public virtual DbSet<PlanEntrenamiento> PlanEntrenamientos { get; set; }

    public virtual DbSet<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; set; }

    public virtual DbSet<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; }

    public virtual DbSet<TipoContacto> TipoContactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-O8MTV2HT; DataBase=GymApp; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ContactoId).HasName("PK__Contacto__8E0F85E877CA5918");

            entity.ToTable("Contacto");

            entity.Property(e => e.ValorContacto).HasMaxLength(100);

            entity.HasOne(d => d.Miembro).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.MiembroId)
                .HasConstraintName("FK_Contacto_Miembro");

            entity.HasOne(d => d.TipoContacto).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.TipoContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacto_TipoContacto");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.EjercicioId).HasName("PK__Ejercici__81222641E7D48FFE");

            entity.ToTable("Ejercicio");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Entrenador>(entity =>
        {
            entity.HasKey(e => e.EntrenadorId).HasName("PK__Entrenad__D0EE8565C5D610C0");

            entity.ToTable("Entrenador");

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Entrenadors)
                .HasForeignKey(d => d.EspecialidadId)
                .HasConstraintName("FK_Entrenador_Especialidad");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.EspecialidadId).HasName("PK__Especial__F9071831DFEC6584");

            entity.ToTable("Especialidad");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__1EEB5921E0BBCA6C");

            entity.ToTable("Evento");

            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Membresium>(entity =>
        {
            entity.HasKey(e => e.MembresiaId).HasName("PK__Membresi__5AE9309750903A3A");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnidadDuracion).HasMaxLength(20);
        });

        modelBuilder.Entity<Miembro>(entity =>
        {
            entity.HasKey(e => e.MiembroId).HasName("PK__Miembro__CC213E59B48846B8");

            entity.ToTable("Miembro");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Membresia).WithMany(p => p.Miembros)
                .HasForeignKey(d => d.MembresiaId)
                .HasConstraintName("FK_Miembro_Membresia");
        });

        modelBuilder.Entity<MiembroEvento>(entity =>
        {
            entity.HasKey(e => e.MiembroEventoId).HasName("PK__MiembroE__13909570072A1B7C");

            entity.ToTable("MiembroEvento");

            entity.HasOne(d => d.Evento).WithMany(p => p.MiembroEventos)
                .HasForeignKey(d => d.EventoId)
                .HasConstraintName("FK_MiembroEvento_Evento");

            entity.HasOne(d => d.Miembro).WithMany(p => p.MiembroEventos)
                .HasForeignKey(d => d.MiembroId)
                .HasConstraintName("FK_MiembroEvento_Miembro");
        });

        modelBuilder.Entity<PlanEntrenamiento>(entity =>
        {
            entity.HasKey(e => e.PlanEntrenamientoId).HasName("PK__PlanEntr__0DF97A81DF8782FB");

            entity.ToTable("PlanEntrenamiento");

            entity.Property(e => e.Nombre).HasMaxLength(30);

            entity.HasOne(d => d.Entrenador).WithMany(p => p.PlanEntrenamientos)
                .HasForeignKey(d => d.EntrenadorId)
                .HasConstraintName("FK_PlanEntrenamiento_Entrenador");
        });

        modelBuilder.Entity<PlanEntrenamientoEjercicio>(entity =>
        {
            entity.HasKey(e => e.PlanEntrenamientoEjercicioId).HasName("PK__PlanEntr__123A0093B6B933F8");

            entity.ToTable("PlanEntrenamientoEjercicio");

            entity.HasOne(d => d.Ejercicio).WithMany(p => p.PlanEntrenamientoEjercicios)
                .HasForeignKey(d => d.EjercicioId)
                .HasConstraintName("FK_PlanEjercicio_Ejercicio");

            entity.HasOne(d => d.PlanEntrenamiento).WithMany(p => p.PlanEntrenamientoEjercicios)
                .HasForeignKey(d => d.PlanEntrenamientoId)
                .HasConstraintName("FK_PlanEjercicio_PlanEntrenamiento");
        });

        modelBuilder.Entity<PlanEntrenamientoMiembro>(entity =>
        {
            entity.HasKey(e => e.PlanEntrenamientoMiembroId).HasName("PK__PlanEntr__B854BF81B5FB50F8");

            entity.ToTable("PlanEntrenamientoMiembro");

            entity.HasOne(d => d.Miembro).WithMany(p => p.PlanEntrenamientoMiembros)
                .HasForeignKey(d => d.MiembroId)
                .HasConstraintName("FK_PlanEntrenamientoMiembro_Miembro");

            entity.HasOne(d => d.PlanEntrenamiento).WithMany(p => p.PlanEntrenamientoMiembros)
                .HasForeignKey(d => d.PlanEntrenamientoId)
                .HasConstraintName("FK_PlanEntrenamientoMiembro_PlanEntrenamiento");
        });

        modelBuilder.Entity<TipoContacto>(entity =>
        {
            entity.HasKey(e => e.TipoContactoId).HasName("PK__TipoCont__2A6E82DC7554D558");

            entity.ToTable("TipoContacto");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
