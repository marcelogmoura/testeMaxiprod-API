using desafioExpenseControl.Application.Dtos;
using ExpenseControl.Application.DTOs;

namespace ExpenseControl.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<PessoaDto> CriarAsync(CreatePessoaDto dto);
        Task<List<PessoaDto>> ListarTodasAsync();        
        Task<List<PessoaTotaisDto>> ListarTotaisAsync();
    }
}