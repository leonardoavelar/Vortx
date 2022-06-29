using Microsoft.EntityFrameworkCore;
using VxTel.Domain.Entity;

namespace VxTel.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Chamada> Chamada { get; }

        public DbSet<Cliente> Cliente { get; }

        public DbSet<Consumo> Consumo { get; }

        public DbSet<Contrato> Contrato { get; }

        public DbSet<Produto> Produto { get; }

        public DbSet<Tarifa> Tarifa { get; }

        public DbSet<TelefoneCliente> TelefoneCliente { get; }

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

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Chamadas)
                    .HasForeignKey(d => d.IdCliente);
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

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Consumos)
                    .HasForeignKey(d => d.IdCliente);
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("Contrato");

                entity.HasIndex(e => e.IdCliente, "IdCliente");

                entity.HasIndex(e => e.IdProduto, "IdProduto");

                entity.Property(e => e.DataContratacao).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdCliente);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdProduto);
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

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.TelefonesCliente)
                    .HasForeignKey(d => d.IdCliente);
            });
        }
    }
}
