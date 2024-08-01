using Microsoft.AspNetCore.Mvc;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {

        private readonly IInscricaoRepositorio _InscricaoRepositorio;

        public InscricaoController(IInscricaoRepositorio InscricaoRepositorio)
        {

            _InscricaoRepositorio = InscricaoRepositorio;

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar Inscrição.",
            Description = "Busca a inscrição cadastrado no banco de dados pelo ID.")]
        public async Task<ActionResult<InscricaoModel>> GetById(int id)
        {

            InscricaoModel? mResult = null;

            try
            {

                mResult = await _InscricaoRepositorio.GetByID(id);

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

        [HttpGet("cpf/{cpf}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar Inscrição.",
            Description = "Busca a inscrição cadastrado no banco de dados pelo CPF.")]
        public async Task<ActionResult<List<InscricaoModel>>> GetByCPF(string cpf)
        {

            List<InscricaoModel>? mResult = null;

            try
            {

                mResult = await _InscricaoRepositorio.GetByCPF(cpf);

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



        [HttpGet("curso/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar Inscrição.",
            Description = "Busca a inscrição cadastrado no banco de dados pelo ID do curso.")]
        public async Task<ActionResult<List<InscricaoModel>>> GetByIdCurso(int id)
        {

            List<InscricaoModel>? mResult = null;

            try
            {

                mResult = await _InscricaoRepositorio.GetByIdCurso(id);

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
        [SwaggerOperation(Summary = "Listar Inscrições.",
            Description = "Lista as inscrições cadastradas no banco de dados.")]
        public async Task<ActionResult<List<InscricaoModel>>> GetAll()
        {

            List<InscricaoModel> mResult = await _InscricaoRepositorio.GetAll();
            return Ok(mResult);

        }
        
        [HttpGet("ativos")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Listar Inscrições.",
            Description = "Lista as inscrições cadastradas no banco de dados.")]
        public async Task<ActionResult<List<InscricaoModel>>> GetAllAtivos()
        {

            List<InscricaoModel> mResult = await _InscricaoRepositorio.GetAllAtivos();
            return Ok(mResult);

        }

        [HttpPost]
        public async Task<ActionResult<InscricaoModel>> Insert([FromBody] InscricaoModel Inscricao)
        {

            InscricaoModel mResult = await _InscricaoRepositorio.Insert(Inscricao);
            return Ok(mResult);

        }

        [HttpPut]
        public async Task<ActionResult<InscricaoModel>> Update([FromBody] InscricaoModel Inscricao)
        {

            InscricaoModel mResult = await _InscricaoRepositorio.Update(Inscricao);
            return Ok(mResult);

        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] int id)
        {

            bool mResult = await _InscricaoRepositorio.Delete(id);
            return Ok(mResult);

        }
    }

}
