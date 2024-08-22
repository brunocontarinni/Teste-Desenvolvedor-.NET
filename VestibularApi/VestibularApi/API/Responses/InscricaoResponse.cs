using System;
using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class InscricaoResponse
    {
        public Guid Id { get; set; }
        public Guid CandidatoId { get; set; }
        public string NomeCandidato { get; set; }
        public Guid OfertaId { get; set; }
        public string NomeOferta { get; set; }
        public DateTime DataInscricao { get; set; }
        public StatusInscricao Status { get; set; }

        public InscricaoResponse(Guid id, Guid candidatoId, string nomeCandidato, Guid ofertaId, string nomeOferta, DateTime dataInscricao, StatusInscricao status)
        {
            Id = id;
            CandidatoId = candidatoId;
            NomeCandidato = nomeCandidato;
            OfertaId = ofertaId;
            NomeOferta = nomeOferta;
            DataInscricao = dataInscricao;
            Status = status;
        }

        public static InscricaoResponse ConverterEntity(InscricaoEntities inscricao)
        {
            return new InscricaoResponse(
                inscricao.Id,
                inscricao.CandidatoId,
                inscricao.Candidato?.Nome ?? string.Empty, 
                inscricao.OfertaId,
                inscricao.Oferta?.Nome ?? string.Empty, 
                inscricao.DataInscricao,
                inscricao.Status 
            );
        }
    }
}
