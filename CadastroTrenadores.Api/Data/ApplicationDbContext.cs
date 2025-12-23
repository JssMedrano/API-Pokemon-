using CadastroTrenadores.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroTrenadores.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Entrenador> Entrenadores => Set<Entrenador>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entrenador = modelBuilder.Entity<Entrenador>();

            entrenador.ToTable("Entrenadores");
            entrenador.HasKey(e => e.Id);
            entrenador.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            entrenador.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entrenador.Property(e => e.Nivel)
                .IsRequired();

            entrenador.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            entrenador.Property(e => e.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            entrenador.Property(e => e.DataRegistro)
                .IsRequired();
        }
    }
}