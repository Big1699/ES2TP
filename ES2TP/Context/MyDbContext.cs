using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ES2TP.Entities;

namespace ES2TP.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<Ativofinanceiro> Ativofinanceiros { get; set; } = null!;
        public virtual DbSet<Depositosprazo> Depositosprazos { get; set; } = null!;
        public virtual DbSet<Fundosinvestimento> Fundosinvestimentos { get; set; } = null!;
        public virtual DbSet<Imovelarrendado> Imovelarrendados { get; set; } = null!;
        public virtual DbSet<Utilizador> Utilizadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=es2;Port=5432;User Id=es2;Password=es2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.Idadmin)
                    .HasName("idadmin_pk");

                entity.ToTable("administrador");

                entity.Property(e => e.Idadmin).HasColumnName("idadmin");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Ativofinanceiro>(entity =>
            {
                entity.HasKey(e => e.Idativofinanceiro)
                    .HasName("idativofinanceiro_pk");

                entity.ToTable("ativofinanceiro");

                entity.Property(e => e.Idativofinanceiro).HasColumnName("idativofinanceiro");

                entity.Property(e => e.Dataini).HasColumnName("dataini");

                entity.Property(e => e.Duracao).HasColumnName("duracao");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Percentagemimposto).HasColumnName("percentagemimposto");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ativofinanceiros)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("iduser_fk");
            });

            modelBuilder.Entity<Depositosprazo>(entity =>
            {
                entity.HasKey(e => e.Iddepositos)
                    .HasName("iddepositos_pk");

                entity.ToTable("depositosprazo");

                entity.Property(e => e.Iddepositos).HasColumnName("iddepositos");

                entity.Property(e => e.Banco)
                    .HasMaxLength(50)
                    .HasColumnName("banco");

                entity.Property(e => e.IdAtivoFinanceiro).HasColumnName("idAtivoFinanceiro");

                entity.Property(e => e.Numeroconta).HasColumnName("numeroconta");

                entity.Property(e => e.Taxajurosanual).HasColumnName("taxajurosanual");

                entity.Property(e => e.Titulares)
                    .HasMaxLength(50)
                    .HasColumnName("titulares");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdAtivoFinanceiroNavigation)
                    .WithMany(p => p.Depositosprazos)
                    .HasForeignKey(d => d.IdAtivoFinanceiro)
                    .HasConstraintName("idativofinanceiro_fk");
            });

            modelBuilder.Entity<Fundosinvestimento>(entity =>
            {
                entity.HasKey(e => e.Idfundos)
                    .HasName("idfundos_pk");

                entity.ToTable("fundosinvestimentos");

                entity.Property(e => e.Idfundos).HasColumnName("idfundos");

                entity.Property(e => e.IdAtivoFinanceiro).HasColumnName("idAtivoFinanceiro");

                entity.Property(e => e.Montanteinvestido).HasColumnName("montanteinvestido");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Taxajuro).HasColumnName("taxajuro");

                entity.HasOne(d => d.IdAtivoFinanceiroNavigation)
                    .WithMany(p => p.Fundosinvestimentos)
                    .HasForeignKey(d => d.IdAtivoFinanceiro)
                    .HasConstraintName("idativofinanceiro_fk");
            });

            modelBuilder.Entity<Imovelarrendado>(entity =>
            {
                entity.HasKey(e => e.Idimovel)
                    .HasName("idimovel_pk");

                entity.ToTable("imovelarrendado");

                entity.Property(e => e.Idimovel).HasColumnName("idimovel");

                entity.Property(e => e.Designacao)
                    .HasMaxLength(50)
                    .HasColumnName("designacao");

                entity.Property(e => e.IdAtivoFinanceiro).HasColumnName("idAtivoFinanceiro");

                entity.Property(e => e.Localizacao)
                    .HasMaxLength(50)
                    .HasColumnName("localizacao");

                entity.Property(e => e.Valoranual).HasColumnName("valoranual");

                entity.Property(e => e.Valorimovel).HasColumnName("valorimovel");

                entity.Property(e => e.Valormensalcondominio).HasColumnName("valormensalcondominio");

                entity.Property(e => e.Valorrenda).HasColumnName("valorrenda");

                entity.HasOne(d => d.IdAtivoFinanceiroNavigation)
                    .WithMany(p => p.Imovelarrendados)
                    .HasForeignKey(d => d.IdAtivoFinanceiro)
                    .HasConstraintName("idativofinanceiro_fk");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("iduser_pk");

                entity.ToTable("utilizador");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
