using ExpenseControl.Domain.Entities;

namespace ExpenseControl.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        Task<Transacao> CreateAsync(Transacao transacao);
        Task<List<Transacao>> GetAllAsync();


    }
}