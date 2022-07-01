using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Application.Service
{
    public sealed class TarifaService : BaseService<TarifaDTO, Tarifa>, ITarifaService
    {
        public TarifaService(IMapper mapper, ITarifaRepository tarifaRepository)
            : base(mapper, tarifaRepository)
        {
        }
    }
}
