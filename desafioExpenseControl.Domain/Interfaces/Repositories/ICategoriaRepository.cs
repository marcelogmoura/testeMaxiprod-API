using DesafioExpenseControl.Domain.Entities;

namespace desafioExpenseControl.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<List<Categoria>> GetAllAsync();

        Task<Categoria?> GetByIdAsync(int id);

    }
}
