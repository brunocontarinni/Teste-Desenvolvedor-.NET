using AutoMapper;
using Inscricoes.Application.Interfaces;

namespace Inscricoes.Application.Mapper;

public class MapperService : IMapperService
{
    private readonly IMapper _mapper;

    public MapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TObjectDestination MapNewObject<TObjectDestination>(object objectEntry)
    {
        TObjectDestination objectDestination = _mapper.Map<TObjectDestination>(objectEntry);
        return objectDestination;
    }

    public void Map(object objectChanges, object objectEntry)
    {
        _mapper.Map(objectChanges, objectEntry);
    }
}
