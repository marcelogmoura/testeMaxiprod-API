using desafioExpenseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.Application.DTOs
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A finalidade é obrigatória.")]
        public FinalidadeCategoria Finalidade { get; set; }
    }
}