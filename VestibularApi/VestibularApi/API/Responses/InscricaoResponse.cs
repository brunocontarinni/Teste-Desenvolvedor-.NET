using System;
using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class InscricaoResponse
    {
        public Guid Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public StatusInscricao Status { get; set; }
        public Guid ProcessoSeletivoId { get; set; }
        public string NomeProcessoSeletivo { get; set; }
        public Guid OfertaId { get; set; }
        public string NomeOferta { get; set; }
        public Guid CandidatoId { get; set; }
        public string NomeCandidato { get; set; }

        public InscricaoResponse(Guid id, string numeroInscricao, DateTime data, StatusInscricao status,
            Guid processoSeletivoId, string nomeProcessoSeletivo,
            Guid ofertaId, string nomeOferta,
            Guid candidatoId, string nomeCandidato)
        {
            Id = id;
            NumeroInscricao = numeroInscricao;
            Data = data;
            Status = status;
            ProcessoSeletivoId = processoSeletivoId;
            NomeProcessoSeletivo = nomeProcessoSeletivo;
            OfertaId = ofertaId;
            NomeOferta = nomeOferta;
            CandidatoId = candidatoId;
            NomeCandidato = nomeCandidato;
        }

        public static InscricaoResponse ConverterEntity(InscricaoEntities inscricao)
        {
            return new InscricaoResponse(
                inscricao.Id,
                inscricao.NumeroInscricao,
                inscricao.Data,
                inscricao.Status,
                inscricao.ProcessoSeletivoId,
                inscricao.ProcessoSeletivo?.Nome ?? string.Empty, 
                inscricao.OfertaId,
                inscricao.Oferta?.Nome ?? string.Empty, 
                inscricao.CandidatoId,
                inscricao.Candidato?.Nome ?? string.Empty
            );
        }
    }
}
