using ExpenseControl.Application.DTOs;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<TransacaoDto> CriarAsync(CreateTransacaoDto dto);
        Task<List<Transacao>> ListarTodasAsync();
    }
}