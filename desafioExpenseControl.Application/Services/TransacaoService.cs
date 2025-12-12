using desafioExpenseControl.Domain.Enums;
using desafioExpenseControl.Domain.Interfaces.Repositories;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Interfaces.Repositories;

namespace ExpenseControl.Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public TransacaoService(
            ITransacaoRepository transacaoRepository,
            IPessoaRepository pessoaRepository,
            ICategoriaRepository categoriaRepository)
        {
            _transacaoRepository = transacaoRepository;
            _pessoaRepository = pessoaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<TransacaoDto> CriarAsync(CreateTransacaoDto dto)
        {
            //se a pessoa existe
            var pessoa = await _pessoaRepository.GetByIdAsync(dto.PessoaId);
            if (pessoa == null)
                throw new Exception("Pessoa não encontrada.");

            //se a categoria existe
            var categoria = await _categoriaRepository.GetByIdAsync(dto.CategoriaId);

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

                        
            if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.Receita)
            {
                throw new Exception("Menores de 18 anos não podem registrar Receitas no momento, apenas Despesas.");
            }

     
            if (categoria.Finalidade != FinalidadeCategoria.Ambas)
            {
                if (dto.Tipo == TipoTransacao.Despesa && categoria.Finalidade == FinalidadeCategoria.Receita)
                    throw new Exception($"A categoria '{categoria.Descricao}' é de Receita e não pode ser usada em uma Despesa.");

                if (dto.Tipo == TipoTransacao.Receita && categoria.Finalidade == FinalidadeCategoria.Despesa)
                    throw new Exception($"A categoria '{categoria.Descricao}' é de Despesa e não pode ser usada em uma Receita.");
            }
                        
            var transacao = new Transacao
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                Tipo = dto.Tipo,
                PessoaId = dto.PessoaId,
                CategoriaId = dto.CategoriaId,
                DataCriacao = DateTime.Now
            };
                        
            var novaTransacao = await _transacaoRepository.CreateAsync(transacao);
                        
            return new TransacaoDto
            {
                Id = novaTransacao.Id,
                Descricao = novaTransacao.Descricao,
                Valor = novaTransacao.Valor,
                Tipo = novaTransacao.Tipo,
                DataCriacao = novaTransacao.DataCriacao,
                PessoaId = novaTransacao.PessoaId,
                CategoriaId = novaTransacao.CategoriaId                
                // NomePessoa = pessoa.Nome,
                // DescricaoCategoria = categoria.Descricao
            };
        }

        public async Task<List<TransacaoDto>> ListarTodasAsync()
        {
            var transacoes = await _transacaoRepository.GetAllAsync();
                        
            return transacoes.Select(t => new TransacaoDto
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Valor = t.Valor,
                Tipo = t.Tipo,
                DataCriacao = t.DataCriacao,
                PessoaId = t.PessoaId,
                CategoriaId = t.CategoriaId
            }).ToList();
        }
    }
}