using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.Application.DTOs
{
    public class CreatePessoaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(1, 150, ErrorMessage = "A idade deve ser um número positivo.")]
        public int Idade { get; set; }
    }
}