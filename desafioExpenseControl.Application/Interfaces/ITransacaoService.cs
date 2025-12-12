using ExpenseControl.Application.DTOs;

namespace ExpenseControl.Application.Interfaces
{
    public interface ITransacaoService
    {
        Task<TransacaoDto> CriarAsync(CreateTransacaoDto dto);
        Task<List<TransacaoDto>> ListarTodasAsync();
    }
}