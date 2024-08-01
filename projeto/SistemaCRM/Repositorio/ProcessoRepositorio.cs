using Microsoft.EntityFrameworkCore;
using SistemaCRM.DAO;
using SistemaCRM.Models;
using SistemaCRM.Repositorio.Interfaces;

namespace SistemaCRM.Repositorio
{
    public class ProcessoRepositorio : IProcessoRepositorio
    {

        private readonly CRMDBContex _dbContext;

        public ProcessoRepositorio(CRMDBContex dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<List<ProcessoModel>> GetAll()
        {

            return await _dbContext.Processos.ToListAsync();

        }

        public async Task<ProcessoModel> GetByID(int id)
        {

            if (id <= 0)
            {

                throw new ArgumentNullException("ID precisa ser maior que 0.");

            }

            ProcessoModel? mProcesso = await _dbContext.Processos.FirstOrDefaultAsync(x => x.Id_processo == id);

            if (mProcesso == null)
            {

                throw new ArgumentException($"Processo para o código {id} não foi localizado.");

            }

            return mProcesso;

        }

        public async Task<ProcessoModel> Insert(ProcessoModel processo)
        {

            ProcessoModel? mProcesso = await _dbContext.Processos.FirstOrDefaultAsync(x => x.Nom_processo.Equals(processo.Nom_processo));

            if (mProcesso != null)
            {

                throw new ArgumentException($"Processo {processo.Nom_processo} já cadastrado.");

            }

            await _dbContext.Processos.AddAsync(processo);
            await _dbContext.SaveChangesAsync();

            return processo;

        }


        public async Task<ProcessoModel> Update(ProcessoModel processo)
        {

            ProcessoModel? mProcesso = await _dbContext.Processos.FirstOrDefaultAsync(x => x.Nom_processo.Equals(processo.Nom_processo) && x.Id_processo != processo.Id_processo);

            if (mProcesso != null)
            {

                throw new ArgumentException($"Processo {processo.Nom_processo} já cadastrado.");

            }

            mProcesso = new ProcessoModel(
                processo.Id_processo,
                processo.Nom_processo,
                processo.Dt_inicio,
                processo.Dt_termino
            );

            _dbContext.ChangeTracker.Clear();
            _dbContext.Processos.Update(mProcesso);
            await _dbContext.SaveChangesAsync();

            return processo;

        }

        public async Task<bool> Delete(int id)
        {

            ProcessoModel mProcesso = await GetByID(id);

            //#IMPLEMENTAR#

            _dbContext.Remove(mProcesso);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }

}
