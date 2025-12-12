using desafioExpenseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.Application.DTOs
{
    public class CreateTransacaoDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 999999999, ErrorMessage = "O valor deve ser positivo e maior que zero.")]
        public decimal Valor { get; set; }

        [Required]
        public TipoTransacao Tipo { get; set; }

        [Required(ErrorMessage = "É necessário informar a Pessoa.")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "É necessário informar a Categoria.")]
        public int CategoriaId { get; set; }
    }
}