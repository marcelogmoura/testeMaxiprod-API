using desafioExpenseControl.Domain.Enums;
using DesafioExpenseControl.Domain.Entities;

namespace ExpenseControl.Domain.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Foreign Keys
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}