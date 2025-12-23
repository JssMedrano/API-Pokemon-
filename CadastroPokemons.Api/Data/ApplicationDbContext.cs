using CadastroPokemons.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPokemons.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons => Set<Pokemon>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var pokemon = modelBuilder.Entity<Pokemon>();

            pokemon.ToTable("Pokemons");
            pokemon.HasKey(p => p.Id);
            pokemon.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            pokemon.Property(p => p.Tipo)
                .IsRequired()
                .HasMaxLength(100);

            pokemon.Property(p => p.Nivel)
                .IsRequired();

            pokemon.Property(p => p.HP)
                .IsRequired();

            pokemon.Property(p => p.Ataque)
                .IsRequired();

            pokemon.Property(p => p.Defesa)
                .IsRequired();

            pokemon.Property(p => p.DataCaptura)
                .IsRequired();

            pokemon.Property(p => p.Descricao)
                .HasMaxLength(500);
        }
    }
}