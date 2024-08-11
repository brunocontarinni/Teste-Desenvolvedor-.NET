using Inscricoes.Application.DTOs.Lead;
using Inscricoes.Application.Services;
using Inscricoes.Application.Tests.MocksInfrastructure;
using Inscricoes.Application.Tests.Provider;
using Inscricoes.Infrastructure.Repositories;
using Inscricoes.Shared.Exceptions;
using FluentAssertions;
using Inscricoes.Domain.Entities;

namespace Inscricoes.Application.Tests.Service
{
	public class LeadServiceTest
	{
		private readonly LeadService _leadService;
		private readonly MapperServiceMock _mapperServiceMock;
		private readonly DatabaseContextProvider _databaseContextProvider;

		public LeadServiceTest()
		{
			_databaseContextProvider = new DatabaseContextProvider();
			_mapperServiceMock = new MapperServiceMock();
			var leadRepository = new LeadRepository(_databaseContextProvider._context);
			_leadService = new LeadService(leadRepository, _mapperServiceMock.UseMock());
		}

		[Fact]
		public async Task CreateLead_WhenCpfAlreadyExists_ThrowsLeadAlreadyExistsException()
		{
			var lead = new Lead { CPF = "12345678900", Email = "test1@test.com", Nome = "Teste 1", Telefone = "111111111" };
			await _databaseContextProvider.CreateData(lead);

			var leadRequestDTO = new CreateLeadRequestDTO { CPF = "12345678900", Email = "test2@test.com", Nome = "Teste 2", Telefone = "222222222" };

			Func<Task> act = async () => await _leadService.CreateLead(leadRequestDTO);

			await act.Should().ThrowAsync<LeadAlreadyExistsException>();
		}

		[Fact]
		public async Task CreateLead_WhenValidData_CreatesLead()
		{
			var leadRequestDTO = new CreateLeadRequestDTO { CPF = "12345678900", Email = "test@test.com", Nome = "Teste", Telefone = "123456789" };

			var result = await _leadService.CreateLead(leadRequestDTO);

			result.CPF.Should().Be(leadRequestDTO.CPF);
			result.Email.Should().Be(leadRequestDTO.Email);
			result.Nome.Should().Be(leadRequestDTO.Nome);
			result.Telefone.Should().Be(leadRequestDTO.Telefone);
		}

		// Outros testes...
	}
}
