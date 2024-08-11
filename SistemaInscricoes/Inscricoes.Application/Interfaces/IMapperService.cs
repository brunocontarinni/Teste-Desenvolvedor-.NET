namespace Inscricoes.Application.Interfaces;

public interface IMapperService
{
	TObjectDestination MapNewObject<TObjectDestination>(object objectEntry);
	void Map(object objectEntry, object objectChanges);
}
