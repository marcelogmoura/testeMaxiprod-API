using desafioExpenseControl.Domain.Enums;
using ExpenseControl.Domain.Entities;

namespace DesafioExpenseControl.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }               
        public string Descricao { get; set; } = string.Empty;
        public FinalidadeCategoria Finalidade { get; set; }
        public ICollection<Transacao> Transacoes { get; set; } = [];
    }
}