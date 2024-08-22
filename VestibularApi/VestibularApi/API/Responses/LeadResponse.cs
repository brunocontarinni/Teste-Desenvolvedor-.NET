using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class LeadResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public LeadResponse(Guid id, string nome, string email, string telefone, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }

        public static LeadResponse ConverterEntity(LeadEntities lead)
        {
            return new LeadResponse(
                lead.Id,
                lead.Nome,
                lead.Email,
                lead.Telefone,
                lead.CPF
            );
        }
    }
}
