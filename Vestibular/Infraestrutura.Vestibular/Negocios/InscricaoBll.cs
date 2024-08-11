using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Negocios
{
    public class InscricaoBll
    {
        private readonly IInscricaoRepository _repository;
        private readonly IMapper _mapper;

        public InscricaoBll(IInscricaoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Criar(InscricaoModelView modelView)
        {
            try
            {
                Inscricao inscricao = _mapper.Map<Inscricao>(modelView);
                return await _repository.Adicionar(inscricao);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InscricaoDto>> ObterTodos()
        {
            try
            {
                var listInscricao = await _repository.ObterTodos();
                return _mapper.Map<IEnumerable<InscricaoDto>>(listInscricao);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InscricaoDto>> ObterTodosPorCPF(string cpf)
        {
            try
            {
                var listInscricao = await _repository.ObterPorCpf(cpf);
                if(listInscricao is IEnumerable<Inscricao>)
                    return _mapper.Map<IEnumerable<InscricaoDto>>(listInscricao);

                throw new NullReferenceException("Inscrição não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InscricaoDto>> ObterTodosPorOferta(int id)
        {
            try
            {
                var listInscricao = await _repository.ObterPorOferta(id);
                if (listInscricao is IEnumerable<Inscricao>)
                    return _mapper.Map<IEnumerable<InscricaoDto>>(listInscricao);

                throw new NullReferenceException("Inscrição não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public async Task<InscricaoDto> ObterPorId(int id)
        {
            try
            {
                var inscricao = await _repository.ObertePorId(id);
                if(inscricao is Inscricao)
                    return _mapper.Map<InscricaoDto>(inscricao);

                throw new NullReferenceException($"Não foi encontrado o {nameof(Inscricao)}");
            }
            catch (Exception) { throw; }
        }

        public async Task Apagar(int id)
        {
            try
            {
                Inscricao inscricao = await _repository.ObertePorId(id);
                if (inscricao is Inscricao)
                    _repository.Deleta(inscricao);
                else
                    throw new NullReferenceException("Inscrição não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public void Atualizar(int id, InscricaoModelView modelView)
        {
            try
            {
                Inscricao inscricao = _mapper.Map<Inscricao>(modelView);
                inscricao.Id = id;
                _repository.Atualizar(inscricao);
            }
            catch (Exception) { throw; }
        }
    }
}
