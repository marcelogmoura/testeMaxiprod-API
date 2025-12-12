using Microsoft.AspNetCore.Mvc;
using ExpenseControl.Application.DTOs;
using ExpenseControl.Application.Interfaces;

namespace ExpenseControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateCategoriaDto dto)
        {
            var result = await _service.CriarAsync(dto);
            return StatusCode(201, result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var result = await _service.ListarTodasAsync();
            return Ok(result);
        }
    }
}