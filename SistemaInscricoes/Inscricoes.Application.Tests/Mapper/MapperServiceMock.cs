using Moq;
using Inscricoes.Application.DTOs.Lead;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;

namespace Inscricoes.Application.Tests.MocksInfrastructure
{
	public class MapperServiceMock : MockBase<IMapperService>
	{
		protected override void SetMock()
		{
			SetMapperLead();
		}

		private void SetMapperLead()
		{
			_mock.Setup(m => m.MapNewObject<DetailLeadResponseDTO>(It.IsAny<Lead>()))
				.Returns((Lead source) => new DetailLeadResponseDTO
				{
					LeadId = source.LeadId,
					Nome = source.Nome,
					Email = source.Email,
					Telefone = source.Telefone,
					CPF = source.CPF
				});

			_mock.Setup(m => m.MapNewObject<CreateLeadResponseDTO>(It.IsAny<Lead>()))
				.Returns((Lead source) => new CreateLeadResponseDTO
				{
					LeadId = source.LeadId,
					Nome = source.Nome,
					Email = source.Email,
					Telefone = source.Telefone,
					CPF = source.CPF
				});

			_mock.Setup(m => m.MapNewObject<UpdateLeadResponseDTO>(It.IsAny<Lead>()))
				.Returns((Lead source) => new UpdateLeadResponseDTO
				{
					LeadId = source.LeadId,
					Nome = source.Nome,
					Email = source.Email,
					Telefone = source.Telefone,
					CPF = source.CPF
				});

			_mock.Setup(m => m.Map(It.IsAny<UpdateLeadRequestDTO>(), It.IsAny<Lead>()))
				.Callback((object entry, object change) =>
				{
					var entryObj = (UpdateLeadRequestDTO)entry;
					var changeObj = (Lead)change;

					changeObj.Nome = entryObj.Nome;
					changeObj.Email = entryObj.Email;
					changeObj.Telefone = entryObj.Telefone;
				});

			_mock.Setup(m => m.MapNewObject<IEnumerable<DetailLeadResponseDTO>>(It.IsAny<IEnumerable<Lead>>()))
				.Returns((IEnumerable<Lead> source) => source.Select(l => new DetailLeadResponseDTO
				{
					LeadId = l.LeadId,
					Nome = l.Nome,
					Email = l.Email,
					Telefone = l.Telefone,
					CPF = l.CPF
				}).ToList());

			_mock.Setup(m => m.MapNewObject<DeleteLeadResponseDTO>(It.IsAny<Lead>()))
				.Returns((Lead source) => new DeleteLeadResponseDTO
				{
					LeadId = source.LeadId,
					Nome = source.Nome,
					Email = source.Email,
					Telefone = source.Telefone,
					CPF = source.CPF
				});
		}
	}

	public abstract class MockBase<T> where T : class
	{
		protected readonly Mock<T> _mock;

		protected MockBase()
		{
			_mock = new Mock<T>();
			SetMock();
		}

		protected abstract void SetMock();

		public T UseMock() => _mock.Object;
	}
}
