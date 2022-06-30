using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Implementation;

namespace VxTel.Application.Service
{
    public abstract class BaseService<D, E> : IBaseService<D, E>
        where D : BaseDTO
        where E : BaseEntity
    {
        protected readonly IMapper _mapper;
        private readonly IBaseRepository<E> _baseRepository;

        public BaseService(IMapper mapper, IBaseRepository<E> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<D> InsertAsync(D dto)
        {
            var entity = _mapper.Map<E>(dto);
            var resultEntity = await _baseRepository.InsertAsync(entity);
            var result = _mapper.Map<D>(resultEntity);
            return result;
        }

        public async Task UpdateAsync(D dto)
        {
            var entity = _mapper.Map<E>(dto);
            await _baseRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            var result = await _baseRepository.ExistAsync(id);
            return result;
        }

        public async Task<D> FindByIdAsync(int id)
        {
            var resultEntity = await _baseRepository.FindByIdAsync(id);
            var result = _mapper.Map<D>(resultEntity);    
            return result;
        }

        public async Task<IEnumerable<D>> FindAllAsync()
        {
            var resultEntity = await _baseRepository.FindAllAsync();
            var result = _mapper.Map<IEnumerable<D>>(resultEntity);
            return result;
        }
    }
}
