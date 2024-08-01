using Microsoft.AspNetCore.Mvc;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {

        private readonly ICandidatoRepositorio _CandidatoRepositorio;

        public CandidatoController(ICandidatoRepositorio CandidatoRepositorio)
        {

            _CandidatoRepositorio = CandidatoRepositorio;

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar candidato.",
            Description = "Busca o candidato cadastrado no banco de dados pelo ID.")]
        public async Task<ActionResult<CandidatoModel>> GetByID(int id)
        {

            CandidatoModel? mResult = null;

            try
            {

                mResult = await _CandidatoRepositorio.GetByID(id);

            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {

                return NotFound(ex.Message);


            }
            catch (Exception ex)
            {

                new Exception(ex.Message);

            }

            return Ok(mResult);

        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Listar Candidatos.",
            Description = "Lista os candidatos cadastrados no banco de dados.")]
        public async Task<ActionResult<List<CandidatoModel>>> GetAll()
        {

            List<CandidatoModel> mResult = await _CandidatoRepositorio.GetAll();
            return Ok(mResult);

        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Inserir Candidato.",
            Description = "Insere o candidato no banco de dados.")]
        public async Task<ActionResult<CandidatoModel>> Insert([FromBody] CandidatoModel candidato)
        {

            CandidatoModel? mResult = null;

            try
            {

                candidato.Validate();
                mResult = await _CandidatoRepositorio.Insert(candidato);


            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {

                return NotFound(ex.Message);


            }
            catch (Exception ex)
            {

                new Exception(ex.Message);

            }

            return Ok(mResult);

        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Alterar Candidato.",
            Description = "Altera o candidato no banco de dados.")]
        public async Task<ActionResult<CandidatoModel>> Update([FromBody] CandidatoModel candidato)
        {

            CandidatoModel? mResult = null;

            try
            {

                candidato.Validate(true);
                mResult = await _CandidatoRepositorio.Update(candidato);

            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {

                return NotFound(ex.Message);


            }
            catch (Exception ex)
            {

                new Exception(ex.Message);

            }

            return Ok(mResult);

        }

        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Deletar Candidato.",
            Description = "Deleta o candidato no banco de dados.")]
        public async Task<ActionResult<bool>> Delete([FromBody] int id)
        {

            bool mResult = false;

            try
            {

                mResult = await _CandidatoRepositorio.Delete(id);

            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);

            }
            catch (ArgumentException ex)
            {

                return NotFound(ex.Message);


            }
            catch (Exception ex)
            {

                new Exception(ex.Message);

            }

            return Ok(mResult);

        }

    }

}
