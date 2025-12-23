using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPokemons.Api.DTOs
{
    public class PokemonDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 150 caracteres.")]
        [DefaultValue("Pikachu")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo pode ter no máximo 100 caracteres.")]
        [DefaultValue("Elétrico")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "O nível é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O nível deve estar entre 1 e 100.")]
        [DefaultValue(25)]
        public required int Nivel { get; set; }

        [Required(ErrorMessage = "O HP é obrigatório.")]
        [Range(1, 500, ErrorMessage = "O HP deve estar entre 1 e 500.")]
        [Column(TypeName = "int")]
        [DefaultValue(100)]
        public required int HP { get; set; }

        [Required(ErrorMessage = "O ataque é obrigatório.")]
        [Range(1, 200, ErrorMessage = "O ataque deve estar entre 1 e 200.")]
        [DefaultValue(55)]
        public required int Ataque { get; set; }

        [Required(ErrorMessage = "A defesa é obrigatória.")]
        [Range(1, 200, ErrorMessage = "A defesa deve estar entre 1 e 200.")]
        [DefaultValue(40)]
        public required int Defesa { get; set; }

        [Required(ErrorMessage = "A data de captura é obrigatória.")]
        [DataType(DataType.Date)]
        [DefaultValue("2024-01-15")]
        public required DateTime DataCaptura { get; set; }

        [StringLength(500)]
        [DefaultValue("Pokémon normal")]
        public string? Descricao { get; set; }
    }
}
