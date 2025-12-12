using desafioExpenseControl.Domain.Interfaces.Repositories;
using DesafioExpenseControl.Domain.Entities;
using ExpenseControl.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias
                .AsNoTracking()
                .OrderBy(c => c.Descricao)
                .ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.Categorias
               .AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}