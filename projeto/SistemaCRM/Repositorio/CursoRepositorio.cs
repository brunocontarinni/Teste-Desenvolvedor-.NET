using Microsoft.EntityFrameworkCore;
using SistemaCRM.DAO;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;

namespace SistemaCRM.Repositorio
{
    public class CursoRepositorio : ICursoRepositorio
    {

        private readonly CRMDBContex _dbContext;

        public CursoRepositorio(CRMDBContex dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<List<CursoModel>> GetAll()
        {

            return await _dbContext.Cursos.ToListAsync();

        }

        public async Task<CursoModel> GetByID(int id)
        {

            if (id <= 0)
            {

                throw new ArgumentNullException("ID precisa ser maior que 0.");

            }

            CursoModel? mResult = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.Id_curso == id);
                        
            if (mResult == null)
            {

                throw new ArgumentException($"Curso para o código {id} não foi localizado.");

            }

            return mResult;

        }

        public async Task<CursoModel> Insert(CursoModel oferta)
        {

            CursoModel? mOferta = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.Nom_curso.Equals(oferta.Nom_curso));

            if (mOferta != null)
            {

                throw new ArgumentException($"Curso {oferta.Nom_curso} já cadastrado.");

            }

            await _dbContext.Cursos.AddAsync(oferta);
            await _dbContext.SaveChangesAsync();

            return oferta;

        }


        public async Task<CursoModel> Update(CursoModel oferta)
        {


            CursoModel? mOferta = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.Nom_curso.Equals(oferta.Nom_curso) && x.Id_curso != oferta.Id_curso);

            if (mOferta != null)
            {

                throw new ArgumentException($"Curso {oferta.Nom_curso} já cadastrado.");

            }

            mOferta = new CursoModel(
                oferta.Id_curso,
                oferta.Nom_curso,
                oferta.Des_curso,
                oferta.Num_vagas
            );

            _dbContext.ChangeTracker.Clear();
            _dbContext.Cursos.Update(mOferta);
            await _dbContext.SaveChangesAsync();

            return mOferta;

        }

        public async Task<bool> Delete(int id)
        {


            CursoModel mOferta = await GetByID(id);

            //#IMPLEMENTAR#

            _dbContext.Remove(mOferta);
            await _dbContext.SaveChangesAsync();

            return true;

        }


    }
}
