
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class Inscricao : Entity
    {
        public Inscricao(string nome, int status, Guid idOferta, Oferta oferta, Guid idLead, Lead lead, Guid idProcessoSeletivo, ProcessoSeletivo processoSeletivo)
        {
            Nome = nome;
            Data = DateTime.Now;
            Status = status;
            IdOferta = idOferta;
            Oferta = oferta;
            IdLead = idLead;
            Lead = lead;
            IdProcessoSeletivo = idProcessoSeletivo;
            ProcessoSeletivo = processoSeletivo;
        }

        public string Nome { get; private set; }
        public DateTime Data { get; private set; }
        public int Status { get; private set; }
        public Guid IdOferta { get; private set; }
        public Oferta Oferta { get; private set; }
        public Guid IdLead { get; private set; }
        public Lead Lead { get; private set; }
        public Guid IdProcessoSeletivo { get; private set; }
        public ProcessoSeletivo ProcessoSeletivo { get; private set; }



    }
}
