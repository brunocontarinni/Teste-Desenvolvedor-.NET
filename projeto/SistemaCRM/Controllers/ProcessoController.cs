using Microsoft.AspNetCore.Mvc;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {

        private readonly IProcessoRepositorio _processoRepositorio;

        public ProcessoController(IProcessoRepositorio processoRepositorio)
        {

            _processoRepositorio = processoRepositorio;

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar Processo.",
            Description = "Busca o processo cadastrado no banco de dados pelo ID.")]
        public async Task<ActionResult<ProcessoModel>> GetByID(int id)
        {

            ProcessoModel? mResult = null;
            try
            {

                mResult = await _processoRepositorio.GetByID(id);

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
        [SwaggerOperation(Summary = "Listar Processos.",
            Description = "Lista os processos cadastrados no banco de dados.")]
        public async Task<ActionResult<List<ProcessoModel>>> GetAll()
        {

            List<ProcessoModel> mResult = await _processoRepositorio.GetAll();
            return Ok(mResult);

        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Inserir Processo.",
            Description = "Insere o processo no banco de dados.")]
        public async Task<ActionResult<ProcessoModel>> Insert([FromBody] ProcessoModel processo)
        {

            ProcessoModel? mResult = null;

            try
            {

                processo.Validate();
                mResult = await _processoRepositorio.Insert(processo);


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
        [SwaggerOperation(Summary = "Alterar Processo.",
            Description = "Altera o processo no banco de dados.")]
        public async Task<ActionResult<ProcessoModel>> Update([FromBody] ProcessoModel processo)
        {

            ProcessoModel? mResult = null;

            try
            {

                processo.Validate(true);
                mResult = await _processoRepositorio.Update(processo);

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

                mResult = await _processoRepositorio.Delete(id);

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
