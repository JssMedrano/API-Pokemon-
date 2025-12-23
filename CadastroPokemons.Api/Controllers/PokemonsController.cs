using CadastroPokemons.Api.Data;
using CadastroPokemons.Api.DTOs;
using CadastroPokemons.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroPokemons.Api.Controllers
{
    [ApiController]
    [Route("api/v1/pokemons")]
    public class PokemonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PokemonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemons = await _context.Pokemons.AsNoTracking().ToListAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(PokemonDto pokemonDto)
        {
            var pokemon = new Pokemon
            {
                Nome = pokemonDto.Nome,
                Tipo = pokemonDto.Tipo,
                Nivel = pokemonDto.Nivel,
                HP = pokemonDto.HP,
                Ataque = pokemonDto.Ataque,
                Defesa = pokemonDto.Defesa,
                DataCaptura = pokemonDto.DataCaptura,
                Descricao = pokemonDto.Descricao
            };

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPokemon(int id, PokemonDto pokemon)
        {
            var existente = await _context.Pokemons.FindAsync(id);
            if (existente == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(pokemon.Nome) || string.IsNullOrWhiteSpace(pokemon.Tipo)
                || pokemon.Nivel <= 0 || pokemon.HP <= 0 || pokemon.Ataque <= 0 || pokemon.Defesa <= 0
                || pokemon.DataCaptura == default)
            {
                return BadRequest("Todos os campos são obrigatórios");
            }

            existente.Nome = pokemon.Nome;
            existente.Tipo = pokemon.Tipo;
            existente.Nivel = pokemon.Nivel;
            existente.HP = pokemon.HP;
            existente.Ataque = pokemon.Ataque;
            existente.Defesa = pokemon.Defesa;
            existente.DataCaptura = pokemon.DataCaptura;
            existente.Descricao = pokemon.Descricao;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}