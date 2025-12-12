using desafioExpenseControl.Domain.Interfaces.Repositories;
using DesafioExpenseControl.Domain.Entities;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Interfaces.Repositories;

namespace ExpenseControl.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaDto> CriarAsync(CreateCategoriaDto dto)
        {
            var categoria = new Categoria
            {
                Descricao = dto.Descricao,
                Finalidade = dto.Finalidade
            };

            var novaCategoria = await _repository.CreateAsync(categoria);

            return new CategoriaDto
            {
                Id = novaCategoria.Id,
                Descricao = novaCategoria.Descricao,
                Finalidade = novaCategoria.Finalidade
            };
        }

        public async Task<List<CategoriaDto>> ListarTodasAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Finalidade = c.Finalidade
            }).ToList();
        }
    }
}