using API_CRM.Helper;
using Microsoft.EntityFrameworkCore;
using SistemaCRM.DAO;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;

namespace SistemaCRM.Repositorio
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {

        private readonly CRMDBContex _dbContext;

        public CandidatoRepositorio(CRMDBContex dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<List<CandidatoModel>> GetAll()
        {

            return await _dbContext.Candidatos.ToListAsync();

        }

        public async Task<CandidatoModel> GetByID(int id)
        {

            if (id <= 0)
            {

                throw new ArgumentNullException("ID precisa ser maior que 0.");

            }

            CandidatoModel? mResult = await _dbContext.Candidatos.FirstOrDefaultAsync(x => x.Id_candidato == id);

            if (mResult == null)
            {

                throw new ArgumentException($"Candidato para o código {id} não foi localizado.");

            }

            return mResult;

        }


        public async Task<CandidatoModel> GetByCPF(string cpf)
        {

            if (string.IsNullOrEmpty(cpf))
            {

                throw new ArgumentNullException("CPF deve ser informado.");

            }
            else if (cpf.Length < 14)
            {

                throw new ArgumentException("CPF deve possuir mais de 13 caracteres.");

            }
            else if (!Helper.IsCpf(cpf))
            {

                throw new ArgumentException($"CPF {cpf} não é um CPF válido.");

            }

            CandidatoModel? mResult = await _dbContext.Candidatos.FirstOrDefaultAsync(x => x.Num_cpf == cpf);

            if (mResult == null)
            {

                throw new ArgumentException($"Candidato para o CPF {cpf} não foi localizado.");

            }

            return mResult;

        }


        public async Task<CandidatoModel> Insert(CandidatoModel candidato)
        {

            CandidatoModel? mCandidato = await _dbContext.Candidatos.FirstOrDefaultAsync(x => x.Num_cpf == candidato.Num_cpf);

            if (mCandidato != null)
            {

                throw new ArgumentException($"CPF {candidato.Num_cpf} já cadastrado.");

            }

            await _dbContext.Candidatos.AddAsync(candidato);
            await _dbContext.SaveChangesAsync();

            return candidato;

        }


        public async Task<CandidatoModel> Update(CandidatoModel candidato)
        {

            CandidatoModel? mCandidato = await _dbContext.Candidatos.FirstOrDefaultAsync(x => x.Num_cpf == candidato.Num_cpf && x.Id_candidato != candidato.Id_candidato);

            if (mCandidato != null)
            {

                throw new ArgumentException($"CPF {candidato.Num_cpf} já cadastrado.");

            }

            mCandidato = new CandidatoModel(
                candidato.Id_candidato,
                candidato.Nom_candidato,
                candidato.Des_email,
                candidato.Num_telefone,
                candidato.Num_cpf
            );

            _dbContext.ChangeTracker.Clear();
            _dbContext.Candidatos.Update(mCandidato);
            await _dbContext.SaveChangesAsync();

            return mCandidato;

        }

        public async Task<bool> Delete(int id)
        {

            CandidatoModel mCandidato = await GetByID(id);

            //#IMPLEMENTAR#

            _dbContext.Remove(mCandidato);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
