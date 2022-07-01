using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VxTel.Domain.Entity;

namespace VxTel.Infrastructure.Database
{
    public partial class vxtelContext : DbContext
    {
        public vxtelContext()
        {
        }

        public vxtelContext(DbContextOptions<vxtelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chamada> Chamada { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Consumo> Consumos { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Tarifa> Tarifas { get; set; }
        public virtual DbSet<TelefoneCliente> TelefoneClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=vxtel;uid=leonardo;password=leonardo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Chamada>(entity =>
            {
                entity.HasIndex(e => e.IdCliente, "IdCliente");

                entity.Property(e => e.DataChamada).HasColumnType("datetime");

                entity.Property(e => e.DataHoraFim).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.DddDestino)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.DddOrigem)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.TempoDuracao).HasColumnType("time");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Chamada)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Chamada_ibfk_1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Consumo>(entity =>
            {
                entity.ToTable("Consumo");

                entity.HasIndex(e => e.IdCliente, "IdCliente");

                entity.Property(e => e.TempoTotal).HasColumnType("time");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Consumo_ibfk_1");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("Contrato");

                entity.HasIndex(e => e.IdCliente, "IdCliente");

                entity.HasIndex(e => e.IdProduto, "IdProduto");

                entity.Property(e => e.DataContratacao).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Contrato_ibfk_1");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("Contrato_ibfk_2");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TempoContratado).HasColumnType("time");
            });

            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.ToTable("Tarifa");

                entity.Property(e => e.DddDestino)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.DddOrigem)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TelefoneCliente>(entity =>
            {
                entity.ToTable("TelefoneCliente");

                entity.HasIndex(e => e.IdCliente, "IdCliente");

                entity.Property(e => e.Ddd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TelefoneClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("TelefoneCliente_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
