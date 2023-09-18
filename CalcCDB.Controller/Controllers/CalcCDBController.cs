using System.Runtime.Versioning;
using CalcCDB.Domain.Interfaces;
using CalcCDB.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalcCDB.Controller.Controllers
{
    [ApiController]
    public class CdbController : ControllerBase
    {
        private readonly ICdbService _cdbService;

        public CdbController(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        [HttpGet]
        [Route("calcular")]
        public async Task<IActionResult> CalcularCdb([FromQuery] decimal valor, [FromQuery] int prazoMeses)
        {

            var mensagens = new List<string>();

            if (valor <= 0)
            {
                mensagens.Add("O valor deve ser maior que zero.");
            }
            if (prazoMeses < 2)
            {
                mensagens.Add("O prazo de meses deve ser maior que 1.");
            }
            if (mensagens.Count > 0)
            {
                return BadRequest(new { Mensagens = mensagens });
            }

            decimal valorBrutoReferencia = await _cdbService.CalcularValorCDBAsync(valor, prazoMeses);
            var cdb = new Cdb
            {
                ValorBruto = valorBrutoReferencia,
                ValorLiquido = await _cdbService.AplicarDescontoImpostoAsync(valorBrutoReferencia, prazoMeses),
                ValorDesconto = await _cdbService.ObterDescontoImpostoAsync(valorBrutoReferencia, prazoMeses),
            };


            return Ok(cdb);
        }
    }
}
