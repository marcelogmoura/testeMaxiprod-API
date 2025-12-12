using desafioExpenseControl.Application.Dtos;
using desafioExpenseControl.Domain.Enums;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities;
using ExpenseControl.Domain.Interfaces.Repositories;

namespace ExpenseControl.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PessoaDto> CriarAsync(CreatePessoaDto dto)
        {            
            if (dto.Idade <= 0)
                throw new Exception("Idade deve ser maior que zero.");
                        
            var pessoa = new Pessoa
            {
                Nome = dto.Nome,
                Idade = dto.Idade
            };

            var novaPessoa = await _pessoaRepository.CreateAsync(pessoa);

            return new PessoaDto
            {
                Id = novaPessoa.Id,
                Nome = novaPessoa.Nome,
                Idade = novaPessoa.Idade
            };
        }

        public async Task<List<PessoaDto>> ListarTodasAsync()
        {
            var pessoas = await _pessoaRepository.GetAllAsync();

            return pessoas.Select(p => new PessoaDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Idade = p.Idade
            }).ToList();
        }

        public async Task<List<PessoaTotaisDto>> ListarTotaisAsync()
        {            
            var pessoas = await _pessoaRepository.GetAllWithTransacoesAsync();

            var listaTotais = new List<PessoaTotaisDto>();

            foreach (var p in pessoas)
            {
                var totalReceitas = p.Transacoes.Where(t => t.Tipo == TipoTransacao.Receita).Sum(t => t.Valor);
                var totalDespesas = p.Transacoes.Where(t => t.Tipo == TipoTransacao.Despesa).Sum(t => t.Valor);

                listaTotais.Add(new PessoaTotaisDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    TotalReceitas = totalReceitas,
                    TotalDespesas = totalDespesas,
                    Saldo = totalReceitas - totalDespesas
                });
            }

            return listaTotais;
        }
    }
}