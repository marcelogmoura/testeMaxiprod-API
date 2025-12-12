using Microsoft.AspNetCore.Mvc;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;
using ExpenseControl.Domain.Entities;

namespace ExpenseControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransacaoDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Criar([FromBody] CreateTransacaoDto dto)
        {
            try
            {  
                var transacaoCriada = await _transacaoService.CriarAsync(dto);

                return StatusCode(201, transacaoCriada);
            }
            catch (Exception ex)
            {          
                return StatusCode(400, new { error = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Transacao>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ListarTodas()
        {
            try
            {
                var transacoes = await _transacaoService.ListarTodasAsync();
                return StatusCode(200, transacoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno ao buscar as transações.", details = ex.Message });
            }
        }
    }
}