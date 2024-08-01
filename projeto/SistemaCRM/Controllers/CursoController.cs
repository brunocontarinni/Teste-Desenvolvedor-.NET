using Microsoft.AspNetCore.Mvc;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ICursoRepositorio _OfertaRepositorio;

        public CursoController(ICursoRepositorio OfertaRepositorio)
        {

            _OfertaRepositorio = OfertaRepositorio;

        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Buscar curso.",
            Description = "Busca o curso cadastrado no banco de dados pelo ID.")]
        public async Task<ActionResult<CursoModel>> GetByID(int id)
        {

            CursoModel? mResult = null;

            try
            {

                mResult = await _OfertaRepositorio.GetByID(id);

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
        [SwaggerOperation(Summary = "Listar Cursos.",
            Description = "Lista os cursos cadastrados no banco de dados.")]
        public async Task<ActionResult<List<CursoModel>>> GetAll()
        {

            List<CursoModel> mResult = await _OfertaRepositorio.GetAll();
            return Ok(mResult);

        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Inserir Curso.",
            Description = "Insere o curso no banco de dados.")]
        public async Task<ActionResult<CursoModel>> Insert([FromBody] CursoModel oferta)
        {

            CursoModel? mResult = null;

            try
            {

                oferta.Validate();
                mResult = await _OfertaRepositorio.Insert(oferta);


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
        [SwaggerOperation(Summary = "Alterar Curso.",
            Description = "Altera o cacurso no banco de dados.")]
        public async Task<ActionResult<CursoModel>> Update([FromBody] CursoModel oferta)
        {


            CursoModel? mResult = null;

            try
            {

                oferta.Validate(true);
                mResult = await _OfertaRepositorio.Update(oferta);


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
        [SwaggerOperation(Summary = "Deletar Curso.",
            Description = "Deleta o curso no banco de dados.")]
        public async Task<ActionResult<bool>> Delete([FromBody] int id)
        {

            bool mResult = await _OfertaRepositorio.Delete(id);
            return Ok(mResult);

        }
    }

}
