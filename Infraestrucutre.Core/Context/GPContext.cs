using System;
using System.Collections.Generic;
using Infraestrucutre.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestrucutre.Core.Context;

public partial class GPContext : DbContext
{
    public GPContext()
    {
    }

    public GPContext(DbContextOptions<GPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitaMedica> CitaMedicas { get; set; }

    public virtual DbSet<EspecialistaModel> Especialista { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<HistoriaClinica> HistoriaClinicas { get; set; }

    public virtual DbSet<HistoriaMedicamento> HistoriaMedicamentos { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Procedimiento> Procedimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitaMedica>(entity =>
        {
            entity.HasKey(e => e.IdCita);

            entity.ToTable("CitaMedica");

            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(1000);

            entity.HasOne(d => d.IdEspecialistaNavigation).WithMany(p => p.CitaMedicas)
                .HasForeignKey(d => d.IdEspecialista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CitaMedica_Especialista");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.CitaMedicas)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CitaMedica_Estado");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.CitaMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CitaMedica_Paciente");
        });

        modelBuilder.Entity<EspecialistaModel>(entity =>
        {
            entity.HasKey(e => e.IdEspecialista);

            entity.Property(e => e.IdEspecialista).ValueGeneratedNever();
            entity.Property(e => e.Especialista).HasMaxLength(50);
            entity.Property(e => e.NombreCompleto).HasMaxLength(150);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("Estado");

            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Estado1)
                .HasMaxLength(50)
                .HasColumnName("Estado");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Genero");

            entity.Property(e => e.Genero1)
                .HasMaxLength(20)
                .HasColumnName("Genero");
        });

        modelBuilder.Entity<HistoriaClinica>(entity =>
        {
            entity.HasKey(e => e.IdHistoria);

            entity.ToTable("HistoriaClinica");

            entity.Property(e => e.Diagnostico).HasMaxLength(500);
            entity.Property(e => e.FechaConsulta).HasColumnType("datetime");
            entity.Property(e => e.ResultadoExamenes).HasMaxLength(2000);
            entity.Property(e => e.Tratamiento).HasMaxLength(1000);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.HistoriaClinicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoriaClinica_Paciente");

            entity.HasOne(d => d.IdProcedimientoNavigation).WithMany(p => p.HistoriaClinicas)
                .HasForeignKey(d => d.IdProcedimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoriaClinica_Procedimiento");
        });

        modelBuilder.Entity<HistoriaMedicamento>(entity =>
        {
            entity.HasOne(d => d.IdHistoriaNavigation).WithMany(p => p.HistoriaMedicamentos)
                .HasForeignKey(d => d.IdHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoriaMedicamentos_HistoriaClinica");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.HistoriaMedicamentos)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoriaMedicamentos_Medicamentos");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento);

            entity.Property(e => e.Dosis)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.ToTable("Paciente");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(12);

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Genero");
        });

        modelBuilder.Entity<Procedimiento>(entity =>
        {
            entity.HasKey(e => e.IdProcedimiento);

            entity.ToTable("Procedimiento");

            entity.Property(e => e.IdProcedimiento).ValueGeneratedNever();
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.NombreProcedimiento).HasMaxLength(100);
            entity.Property(e => e.Resultado).HasMaxLength(500);

            entity.HasOne(d => d.IdEspecialistaNavigation).WithMany(p => p.Procedimientos)
                .HasForeignKey(d => d.IdEspecialista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procedimiento_Especialista");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
