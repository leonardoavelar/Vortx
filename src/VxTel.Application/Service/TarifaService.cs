using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class TarifaService : BaseService<TarifaDTO, Tarifa>, ITarifaService
    {
        public TarifaService(IMapper mapper, ITarifaRepository tarifaRepository)
            : base(mapper, tarifaRepository)
        {
        }
    }
}
