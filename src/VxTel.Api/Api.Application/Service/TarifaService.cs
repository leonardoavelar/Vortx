using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Application.Service
{
    public sealed class TarifaService : BaseService<TarifaDTO, Tarifa>, ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(IMapper mapper, ITarifaRepository tarifaRepository)
            : base(mapper, tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public async Task<TarifaDTO> FindByOrigemDestinoAsync(string dddOrigem, string dddDestino)
        {
            var resultEntity = await _tarifaRepository.FindByOrigemDestinoAsync(dddOrigem, dddDestino);
            var result = _mapper.Map<TarifaDTO>(resultEntity);
            return result;
        }
    }
}
