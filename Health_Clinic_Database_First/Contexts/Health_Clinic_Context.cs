using System;
using System.Collections.Generic;
using Health_Clinic_Database_First.Domains;
using Microsoft.EntityFrameworkCore;

namespace Health_Clinic_Database_First.Contexts;

public partial class Health_Clinic_Context : DbContext
{
    public Health_Clinic_Context()
    {
    }

    public Health_Clinic_Context(DbContextOptions<Health_Clinic_Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultorio> Clinica { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TiposDeUsuario> TiposDeUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public object Consultum { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       //  => optionsBuilder.UseSqlServer("Data Source=NOTE13-S15; initial catalog=Health_Clinic; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");

      => optionsBuilder.UseSqlServer("Data Source=127.0.0.1; initial catalog=Health_Clinic; User Id = sa; Pwd = mwm123; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.IdClinica).HasName("PK__Clinica__5AB835FC193D05B2");

            entity.ToTable("Clinica");

            entity.HasIndex(e => e.NomeFantasia, "UQ__Clinica__A1456661BC97B0E8").IsUnique();

            entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__B0E5930EC6C24886").IsUnique();

            entity.HasIndex(e => e.Cep, "UQ__Clinica__C1FF39CF3064E734").IsUnique();

            entity.Property(e => e.IdClinica)
                .ValueGeneratedNever()
                .HasColumnName("ID_Clinica");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CEP");
            entity.Property(e => e.Endereco)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Nome_Fantasia");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Razao_Social");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__9DA76AFEEFAEC774");

            entity.Property(e => e.IdConsulta)
                .ValueGeneratedNever()
                .HasColumnName("ID_Consulta");
            entity.Property(e => e.DataDaConsulta)
                .HasColumnType("date")
                .HasColumnName("Data_da_Consulta");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Feedback).HasColumnType("text");
            entity.Property(e => e.HorarioDaConsulta).HasColumnName("Horario_da_Consulta");
            entity.Property(e => e.IdMedico).HasColumnName("ID_Medico");
            entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__ID_Med__4E88ABD4");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__ID_Pac__4F7CD00D");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade).HasName("PK__Especial__22ADE50D58308749");

            entity.ToTable("Especialidade");

            entity.Property(e => e.IdEspecialidade)
                .ValueGeneratedNever()
                .HasColumnName("ID_Especialidade");
            entity.Property(e => e.EspecialidadeMedica)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Especialidade_Medica");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__EFBF88F759C28157");

            entity.ToTable("Medico");

            entity.Property(e => e.IdMedico)
                .ValueGeneratedNever()
                .HasColumnName("ID_Medico");
            entity.Property(e => e.Crm)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CRM");
            entity.Property(e => e.IdClinica).HasColumnName("ID_Clinica");
            entity.Property(e => e.IdEspecialidade).HasColumnName("ID_Especialidade");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdClinica)
                .HasConstraintName("FK__Medico__ID_Clini__4AB81AF0");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidade)
                .HasConstraintName("FK__Medico__ID_Espec__4BAC3F29");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__ID_Usuar__49C3F6B7");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__5F365061A2426BBB");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C816F908ED").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731B36E4913").IsUnique();

            entity.Property(e => e.IdPaciente)
                .ValueGeneratedNever()
                .HasColumnName("ID_Paciente");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataDeNascimento)
                .HasColumnType("date")
                .HasColumnName("Data_de_Nascimento");
            entity.Property(e => e.Endereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDaResidencia).HasColumnName("Numero_da_Residencia");
            entity.Property(e => e.Rg)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RG");
            entity.Property(e => e.Sexo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__ID_Usu__403A8C7D");
        });

        modelBuilder.Entity<TiposDeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeUsuario).HasName("PK__TiposDeU__65E879EF9C8B8D54");

            entity.ToTable("TiposDeUsuario");

            entity.Property(e => e.IdTipoDeUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_TipoDeUsuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C50160762B");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Nome, "UQ__Usuario__7D8FE3B2B228CACD").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534A6855A9B").IsUnique();

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdTipoDeUsuario).HasColumnName("ID_TipoDeUsuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDeUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDeUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__ID_Tipo__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
