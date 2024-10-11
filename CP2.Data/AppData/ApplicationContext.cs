using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<FornecedorEntity> Fornecedores { get; set; }
        public DbSet<VendedorEntity> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendedorEntity>(entity =>
            {
                entity.Property(e => e.ComissaoPercentual)
                      .HasPrecision(18, 2);  // Define a precisão: 18 dígitos no total, 2 após o ponto decimal

                entity.Property(e => e.MetaMensal)
                      .HasPrecision(18, 2);  // Define a precisão: 18 dígitos no total, 2 após o ponto decimal
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}