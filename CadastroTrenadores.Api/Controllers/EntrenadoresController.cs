using CadastroTrenadores.Api.Data;
using CadastroTrenadores.Api.Models;
using CadastroTrenadores.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroTrenadores.Api.Controllers
{
    [ApiController]
    [Route("api/v1/entrenadores")]
    public class EntrenadoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntrenadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrenador>>> GetEntrenadores()
        {
            var entrenadores = await _context.Entrenadores.AsNoTracking().ToListAsync();
            return Ok(entrenadores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Entrenador>> GetEntrenador(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador == null)
            {
                return NotFound();
            }
            return Ok(entrenador);
        }

        [HttpPost]
        public async Task<ActionResult<Entrenador>> PostEntrenador(EntrenadorDto entrenadorDto)
        {
            var entrenador = new Entrenador
            {
                Nome = entrenadorDto.Nome,
                Email = entrenadorDto.Email,
                Nivel = entrenadorDto.Nivel,
                Cidade = entrenadorDto.Cidade,
                Telefone = entrenadorDto.Telefone,
                DataRegistro = entrenadorDto.DataRegistro
            };

            _context.Entrenadores.Add(entrenador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntrenador), new { id = entrenador.Id }, entrenador);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEntrenador(int id, EntrenadorDto entrenador)
        {
            var existente = await _context.Entrenadores.FindAsync(id);
            if (existente == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(entrenador.Nome) || string.IsNullOrWhiteSpace(entrenador.Email)
                || string.IsNullOrWhiteSpace(entrenador.Cidade) || string.IsNullOrWhiteSpace(entrenador.Telefone)
                || entrenador.Nivel <= 0 || entrenador.DataRegistro == default)
            {
                return BadRequest("Todos os campos são obrigatórios");
            }

            existente.Nome = entrenador.Nome;
            existente.Email = entrenador.Email;
            existente.Nivel = entrenador.Nivel;
            existente.Cidade = entrenador.Cidade;
            existente.Telefone = entrenador.Telefone;
            existente.DataRegistro = entrenador.DataRegistro;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEntrenador(int id)
        {
            var entrenador = await _context.Entrenadores.FindAsync(id);
            if (entrenador == null)
            {
                return NotFound();
            }

            _context.Entrenadores.Remove(entrenador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}