using desafioExpenseControl.Domain.Enums;

namespace ExpenseControl.Application.DTOs
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int PessoaId { get; set; }
        public int CategoriaId { get; set; }
    }
}