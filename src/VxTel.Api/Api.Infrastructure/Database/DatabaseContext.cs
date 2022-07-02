using Microsoft.EntityFrameworkCore;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Chamada> Chamada { get; }

        public virtual DbSet<Cliente> Cliente { get; }

        public virtual DbSet<Consumo> Consumo { get; }

        public virtual DbSet<Contrato> Contrato { get; }

        public virtual DbSet<Produto> Produto { get; }

        public virtual DbSet<Tarifa> Tarifa { get; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chamada>(entity =>
            {
                entity.ToTable("Chamada");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.ClienteId, "ClienteId");

                entity.Property(e => e.DddOrigem)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.TelefoneOrigem)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.DddDestino)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.TelefoneDestino)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.DataChamada).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.DataHoraFim).HasColumnType("datetime");

                entity.Property(e => e.TempoDuracao).HasColumnType("time");

                entity.Property(e => e.Valor).HasColumnType("double");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Chamadas)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Ddd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Consumo>(entity =>
            {
                entity.ToTable("Consumo");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.ClienteId, "ClienteId");

                entity.Property(e => e.TempoTotal).HasColumnType("time");

                entity.Property(e => e.Valor).HasColumnType("double");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("Contrato");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.ClienteId, "ClienteId");

                entity.HasIndex(e => e.ProdutoId, "ProdutoId");

                entity.Property(e => e.DataContratacao).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ClienteId);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ProdutoId);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TempoContratado).HasColumnType("time");

                entity.Property(e => e.PercentualAcrescimo).HasColumnType("double");

                entity.Property(e => e.Valor).HasColumnType("double");
            });

            modelBuilder.Entity<Tarifa>(entity =>
            {
                entity.ToTable("Tarifa");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.DddDestino)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.DddOrigem)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Valor).HasColumnType("double");
            });
        }
    }
}
