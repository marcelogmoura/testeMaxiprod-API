using ExpenseControl.Application.DTOs;

namespace ExpenseControl.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> CriarAsync(CreateCategoriaDto dto);
        Task<List<CategoriaDto>> ListarTodasAsync();
    }
}