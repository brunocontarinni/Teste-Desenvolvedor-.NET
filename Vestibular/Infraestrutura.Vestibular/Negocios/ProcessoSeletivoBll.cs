using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Negocios
{
    public class ProcessoSeletivoBll
    {
        private readonly IProcessoSeletivoRepository _repository;
        private readonly IMapper _mapper;

        public ProcessoSeletivoBll(IProcessoSeletivoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Criar(ProcessoSeletivoModelView modelView)
        {
            try
            {
                ProcessoSeletivo processo = _mapper.Map<ProcessoSeletivo>(modelView);
                return await _repository.Adicionar(processo);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<ProcessoSeletivoDto>> ObterTodos()
        {
            try
            {
                var listProcesso = await _repository.ObterTodos();
                return _mapper.Map<IEnumerable<ProcessoSeletivoDto>>(listProcesso);
            }
            catch (Exception) { throw; }
        }

        public async Task<ProcessoSeletivoDto> ObterPorId(int id)
        {
            try
            {
                var processo = await _repository.ObterPorId(id);
                if(processo is ProcessoSeletivo)
                    return _mapper.Map<ProcessoSeletivoDto>(processo);

                throw new NullReferenceException($"Não foi encontrado o {nameof(ProcessoSeletivo)}");
            }
            catch (Exception) { throw; }
        }

        public async Task Apagar(int id)
        {
            try
            {
                ProcessoSeletivo processo = await _repository.ObterPorId(id);
                if (processo is ProcessoSeletivo)
                    _repository.Deleta(processo);
                else
                    throw new NullReferenceException("Oferta não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public void Atualizar(int id, ProcessoSeletivoModelView modelView)
        {
            try
            {
                ProcessoSeletivo processo = _mapper.Map<ProcessoSeletivo>(modelView);
                processo.Id = id;
                _repository.Atualizar(processo);
            }
            catch (Exception) { throw; }
        }
    }
}
