using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> CreateAsync(Pessoa pessoa);
        Task<Pessoa?> GetByIdAsync(int id);
        Task<List<Pessoa>> GetAllAsync();

        // relatório de Totais        
        Task<List<Pessoa>> GetAllWithTransacoesAsync();

        Task DeleteAsync(Pessoa pessoa);
    }
}