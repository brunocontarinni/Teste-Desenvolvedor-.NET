using Microsoft.EntityFrameworkCore;
using SistemaCRM.DAO;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;

namespace SistemaCRM.Repositorio
{
    public class InscricaoRepositorio : IInscricaoRepositorio
    {

        private readonly CRMDBContex _dbContext;

        public InscricaoRepositorio(CRMDBContex dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<List<InscricaoModel>> GetAll()
        {

            return await _dbContext.Inscricoes.ToListAsync();

        }

        public async Task<List<InscricaoModel>> GetAllAtivos()
        {

            return await _dbContext.Inscricoes.Where(x => x.Processo != null && x.Processo.Dt_termino >= DateTime.Now).ToListAsync();

        }

        public async Task<InscricaoModel> GetByID(int id)
        {

            if (id <= 0)
            {

                throw new ArgumentNullException("ID precisa ser maior que 0.");

            }

            InscricaoModel? mInscricao = await _dbContext.Inscricoes.FirstOrDefaultAsync(x => x.Id_inscricao == id);

            if (mInscricao == null)
            {

                throw new ArgumentException($"Inscrição para o código {id} não foi localizada.");

            }

            return mInscricao;

        }
        

        public async Task<List<InscricaoModel>> GetByCPF(string cpf)
        {

            CandidatoModel? mCandidato = await new CandidatoRepositorio(_dbContext).GetByCPF(cpf);

            List<InscricaoModel>? mInscricao = await _dbContext.Inscricoes.Where(x => x.Candidadto != null && x.Candidadto.Num_cpf.Equals(cpf)).ToListAsync();

            if (mInscricao == null)
            {

                throw new ArgumentException($"Inscrições para o candidato {mCandidato.Nom_candidato} não foram localizadas.");

            }

            return mInscricao;

        }

        public async Task<List<InscricaoModel>> GetByIdCurso(int id)
        {

            if (id <= 0)
            {

                throw new ArgumentNullException("ID precisa ser maior que 0.");

            }

            CursoModel? mCurso = await new CursoRepositorio(_dbContext).GetByID(id);

            List<InscricaoModel>? mInscricao = await _dbContext.Inscricoes.Where(x => x.Curso != null && x.Curso.Id_curso == id).ToListAsync();

            if (mInscricao == null)
            {

                throw new Exception($"Inscrições para o curso {mCurso.Nom_curso} não foram localizadas.");

            }

            return mInscricao;

        }

        public async Task<InscricaoModel> Insert(InscricaoModel inscricao)
        {

            ProcessoModel? mProcesso = await new ProcessoRepositorio(_dbContext).GetByID(inscricao.id_processo);
            CursoModel? mCurso = await new CursoRepositorio(_dbContext).GetByID(inscricao.id_curso);
            CandidatoModel? mCandidato = await new CandidatoRepositorio(_dbContext).GetByID(inscricao.id_candidato);
            
            InscricaoModel? mInscricao = await _dbContext.Inscricoes.FirstOrDefaultAsync(x => x.Num_inscricao == inscricao.Num_inscricao);

            if (mInscricao != null)
            {

                throw new ArgumentException($"Inscrição {inscricao.Num_inscricao} já cadastrada.");

            }

            await _dbContext.Inscricoes.AddAsync(inscricao);
            await _dbContext.SaveChangesAsync();

            return inscricao;

        }


        public async Task<InscricaoModel> Update(InscricaoModel inscricao)
        {


            ProcessoModel? mProcesso = await new ProcessoRepositorio(_dbContext).GetByID(inscricao.id_processo);
            CursoModel? mCurso = await new CursoRepositorio(_dbContext).GetByID(inscricao.id_curso);
            CandidatoModel? mCandidato = await new CandidatoRepositorio(_dbContext).GetByID(inscricao.id_candidato);

            InscricaoModel? mInscricao = await _dbContext.Inscricoes.FirstOrDefaultAsync(x => x.Num_inscricao == inscricao.Num_inscricao && x.Id_inscricao != inscricao.Id_inscricao);

            if (mInscricao != null)
            {

                throw new ArgumentException($"Inscrição {inscricao.Num_inscricao} já cadastrada.");

            }

            mInscricao = new InscricaoModel(
                inscricao.Id_inscricao,
                inscricao.Num_inscricao,
                inscricao.Dt_inscricao,
                inscricao.Tag_status,
                inscricao.id_candidato,
                inscricao.id_processo,
                inscricao.id_curso
            );

            _dbContext.ChangeTracker.Clear();
            _dbContext.Inscricoes.Update(mInscricao);
            await _dbContext.SaveChangesAsync();

            return mInscricao;

        }

        public async Task<bool> Delete(int id)
        {


            InscricaoModel mInscricao = await GetByID(id);

            _dbContext.Remove(mInscricao);
            await _dbContext.SaveChangesAsync();

            return true;

        }


    }
}
