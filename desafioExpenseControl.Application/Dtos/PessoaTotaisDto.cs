namespace ExpenseControl.Application.DTOs
{
    public class PessoaTotaisDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //campos específicos do relatório
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo { get; set; }
    }
}