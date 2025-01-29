using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;


namespace Application.Services
{
    public class BaseService<TEntity, TDTO>
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<TEntity> Create(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var response = await _repository.AddAsync(entity);
            return response;
        }
        public async Task<bool> Update(int id, TDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity == null)
            {
                return false;
            }
            _mapper.Map(dto, entity);
            return await _repository.UpdateAsync(entity);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}