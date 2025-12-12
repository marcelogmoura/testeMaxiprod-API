using Microsoft.AspNetCore.Mvc;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;

namespace ExpenseControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreatePessoaDto dto)
        {
            try
            {
                var result = await _pessoaService.CriarAsync(dto);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await _pessoaService.ListarTodasAsync();
            return Ok(result);
        }

        [HttpGet("totais")]
        public async Task<IActionResult> ListarTotais()
        {
            // Endpoint para o relatório do teste
            var result = await _pessoaService.ListarTotaisAsync();
            return Ok(result);
        }
    }
}