using Microsoft.EntityFrameworkCore;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Interfaces.Repositories;
using ExpenseControl.Infrastructure.Context;

namespace ExpenseControl.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa?> GetByIdAsync(int id)
        {            
            return await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas
                .AsNoTracking()
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<List<Pessoa>> GetAllWithTransacoesAsync()
        {            
            return await _context.Pessoas
                .Include(p => p.Transacoes) //traz as transações
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteAsync(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}