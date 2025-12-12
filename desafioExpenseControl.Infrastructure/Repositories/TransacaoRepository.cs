using Microsoft.EntityFrameworkCore;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Interfaces.Repositories;
using ExpenseControl.Infrastructure.Context;

namespace ExpenseControl.Infrastructure.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public TransacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transacao> CreateAsync(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }

        public async Task<List<Transacao>> GetAllAsync()
        {            
            return await _context.Transacoes
                .Include(t => t.Pessoa)
                .Include(t => t.Categoria)
                .AsNoTracking()
                .OrderByDescending(t => t.DataCriacao) //recentes primeiro
                .ToListAsync();
        }
    }
}