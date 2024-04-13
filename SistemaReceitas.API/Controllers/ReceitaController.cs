using Microsoft.AspNetCore.Mvc;
using SistemaReceitas.Application.InputModel;
using SistemaReceitas.Application.Services;
using SistemaReceitas.Core.Enums;

namespace SistemaReceitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceitas()
        {
            var receitas = await _receitaService.GetAll();
            return Ok(receitas);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReceitaById(int id)
        {
            var receita = await _receitaService.GetById(id);
            return Ok(receita);
        }
        [HttpPost("criar-receita")]
        public async Task<IActionResult> PostReceita(AdicionarReceitaInputModel model)
        {
            var response = await _receitaService.Create(model);
            return Ok(new
            {
                Info = response
            });
        }
        [HttpPut("curtir-receita/{id:int}")]
        public async Task<IActionResult> PutCurtirReceita(int id)
        {
            var response = await _receitaService.Update(id, Reacao.GOSTEI);
            return Ok(new
            {
                Info = response,
            });

        }
        [HttpPut("nao-curtir-receita/{id:int}")]
        public async Task<IActionResult> PutNaoCurtirReceita(int id)
        {
            var response = await _receitaService.Update(id, Reacao.NAO_GOSTEI);
            return Ok(new
            {
                Info = response,
            });
        }
    }
}
