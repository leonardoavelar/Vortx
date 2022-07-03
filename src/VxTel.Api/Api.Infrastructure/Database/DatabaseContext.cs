using Microsoft.EntityFrameworkCore;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Produto> Produto { get; }

        public virtual DbSet<Tarifa> Tarifa { get; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
