using Moq;

namespace Inscricoes.Application.Tests.Mapper;

public class MockBase<T> where T : class
{
	protected readonly Mock<T> _mock;

	public MockBase()
	{
		_mock = new Mock<T>();
		SetMock();
	}

	protected virtual void SetMock()
	{
	}

	public Mock<T> GetMock()
	{
		return _mock;
	}

	public T UseMock()
	{
		return _mock.Object;
	}
}
