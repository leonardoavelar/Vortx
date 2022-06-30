using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ConsumoService : BaseService<ConsumoDTO, Consumo>, IConsumoService
    {
        private readonly IConsumoRepository _consumoRepository;

        public ConsumoService(IMapper mapper, IConsumoRepository consumoRepository)
            : base(mapper, consumoRepository)
        {
            _consumoRepository = consumoRepository;
        }

        public async Task<IEnumerable<ConsumoDTO>> FindByClienIdAsync(int idClient)
        {
            var resultEntity = await _consumoRepository.FindByClienIdAsync(idClient);
            var result = _mapper.Map<IEnumerable<ConsumoDTO>>(resultEntity);
            return result;
        }
    }
}
