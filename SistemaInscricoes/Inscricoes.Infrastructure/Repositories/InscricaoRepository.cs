using Inscricoes.Application.Validations;
using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Inscricoes.Shared.Constants;
using Inscricoes.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Repositories;

public class InscricaoRepository : BaseRepository<Inscricao>, IInscricaoRepository
{
	public InscricaoRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<IEnumerable<Inscricao>> GetByCpfAsync(string cpf)
	{
		var cpfValidator = new CpfValidationAttribute();

		bool isValid = cpfValidator.IsValid(cpf);

		if (!isValid)
		{
			throw new ArgumentException(MessageKeyConstants.MESSAGE_ERROR_CPF_INVALID);
		}

		string normalizedCpf = cpf.NormalizeToSearch();

		List<Inscricao> inscricoes = await _context.Inscricoes
			.Include(i => i.Lead)
			.Include(i => i.ProcessoSeletivo)
			.AsNoTracking() 
			.ToListAsync();

		return inscricoes
			.Where(i => i.Lead.CPF.NormalizeToSearch() == normalizedCpf);
	}

	public async Task<IEnumerable<Inscricao>> GetByOfertaIdAsync(int ofertaId)
	{
		List<Inscricao> inscricoes = await _context.Inscricoes
			.Where(i => i.OfertaId == ofertaId)
			.AsNoTracking()
			.ToListAsync();

		return inscricoes;
	}
}
