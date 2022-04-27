using Microsoft.AspNetCore.Mvc;
using System;

namespace robo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BracoController : ControllerBase
    {
        // declara array braco com seus estados iniciais (em repouso) onde:
        // braco[0] => braco esquerdo
        // braco[1] => braco direito
        private static Braco[] braco = {
            new Braco()
            {
                Cotovelo = (int)Braco.ECotovelo.EmRepouso,
                Pulso = (int)Braco.EPulso.EmRepouso
            },
            new Braco()
            {
                Cotovelo = (int)Braco.ECotovelo.EmRepouso,
                Pulso = (int)Braco.EPulso.EmRepouso
            }
        };

        // funcao que retorna estados de todos os bracos
        [HttpGet]
        public ActionResult<Braco[]> Get()
        {
            return Ok(braco);
        }

        [HttpGet("{id}")]
        public ActionResult<Braco> Get(int id)
        {
            if (id < 0 || id >= braco.Length)
                return BadRequest("Este braco nao existe");

            return Ok(braco[id]);
        }


        [HttpPut("Cotovelo")]
        public ActionResult<Braco[]> UpdateBracoCotovelo(int id, int NovoCotovelo)
        {
            if (id < 0 || id >= braco.Length)
                return BadRequest("Este braco nao existe");

            int cotoveloAtual = braco[id].Cotovelo;


            if (NovoCotovelo < (int)Braco.ECotovelo.EmRepouso || NovoCotovelo > (int)Braco.ECotovelo.FortementeContraido)
            {
                return BadRequest("Comando invalido");
            }
            else if (Math.Abs(NovoCotovelo - cotoveloAtual) > 1)
            {
                return BadRequest("Só é possivel realizar movimentos suaves");
            }

            braco[id].Cotovelo = NovoCotovelo;
                
            return Ok(braco);
        }


        [HttpPut("Pulso")]
        public ActionResult<Braco[]> UpdateBracoPulso(int id, int NovoPulso)
        {
            if (id < 0 || id >= braco.Length)
                return BadRequest("Este braco nao existe");

            int cotoveloAtual = braco[id].Cotovelo;
            int pulsoAtual = braco[id].Pulso;

            if (cotoveloAtual != (int)Braco.ECotovelo.FortementeContraido)
            {
                return BadRequest("Nao é possivel rotacionar enquanto cotovelo nao estiver Fortemente Contraido");
            }
            else if (NovoPulso < (int)Braco.EPulso.RotacaoNeg90 || NovoPulso > (int)Braco.EPulso.Rotacao180)
            {
                return BadRequest("Comando invalido");
            }
            else if (Math.Abs(NovoPulso - pulsoAtual) > 1)
            {
                return BadRequest("Só é possivel realizar movimentos suaves");
            }

            braco[id].Pulso = NovoPulso;
            return Ok(braco);
        }

    }
}
