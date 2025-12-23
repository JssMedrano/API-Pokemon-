using System.ComponentModel.DataAnnotations;

namespace CadastroTrenadores.Api.DTOs
{
    public class EntrenadorDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(
            200,
            MinimumLength = 3,
            ErrorMessage = "O nome precisa ter entre 3 e 200 caracteres."
        )]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [StringLength(255)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Nível de experiência é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O nível deve estar entre 1 e 100.")]
        public required int Nivel { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "A cidade precisa ter entre 2 e 100 caracteres.")]
        public required string Cidade { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [RegularExpression(
            @"^\d{2}\d{4,5}\d{4}$",
            ErrorMessage = "Telefone inválido."
        )]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "Data de registro é obrigatória.")]
        [DataType(DataType.Date)]
        public required DateTime DataRegistro { get; set; }
    }
}
