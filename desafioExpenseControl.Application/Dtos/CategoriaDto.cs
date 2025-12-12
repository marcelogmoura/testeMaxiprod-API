using desafioExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public FinalidadeCategoria Finalidade { get; set; }

    }
}