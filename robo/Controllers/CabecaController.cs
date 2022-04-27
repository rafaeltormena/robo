using Microsoft.AspNetCore.Mvc;
using System;

namespace robo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabecaController : ControllerBase
    {
        private static Cabeca cabeca = new Cabeca()
        {
            Inclinacao = (int)Cabeca.EInclinacao.EmRepouso,
            Rotacao = (int)Cabeca.ERotacao.EmRepouso
        };
        

        [HttpGet]
        public ActionResult<Cabeca> Get()
        {
            return Ok(cabeca);
        }


        [HttpPut("Rotacionar")]
        public ActionResult<Cabeca> UpdateCabecaRotacao(int NovaRotacao)
        {
            int inclinacaoAtual = cabeca.Inclinacao;

            if (inclinacaoAtual == (int)Cabeca.EInclinacao.ParaBaixo)
            {
                return BadRequest("Nao é possivel rotacionar enquanto inclinação para baixo");
            }
            else if (NovaRotacao < (int)Cabeca.ERotacao.RotacaoNeg90 || NovaRotacao > (int)Cabeca.ERotacao.Rotacao90)
            {
                return BadRequest("Comando invalido");
            }
            else if (Math.Abs(NovaRotacao - cabeca.Rotacao) > 1)
            {
                return BadRequest("Só é possivel realizar movimentos suaves");
            }

            cabeca.Rotacao = NovaRotacao;
            return Ok(cabeca);
        }
        
        [HttpPut("Inclinar")]
        public ActionResult<Cabeca> UpdateCabecaInclinacao(int NovaInclinacao)
        {
            int inclinacaoAtual = cabeca.Inclinacao;

            if (NovaInclinacao < 1 || NovaInclinacao > 3)
            {
                return BadRequest("Comando invalido");
            }
            else if (Math.Abs(NovaInclinacao - inclinacaoAtual) > 1)
            {
                return BadRequest("Só é possivel realizar movimentos suaves");
            }

            cabeca.Inclinacao = NovaInclinacao;
            return Ok(cabeca);
        }
        
    }
}
