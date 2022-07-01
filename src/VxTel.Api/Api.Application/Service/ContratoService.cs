using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;

namespace VxTel.Api.Application.Service
{
    public sealed class ContratoService : BaseService<ContratoDTO, Contrato>, IContratoService
    {
        public ContratoService(IMapper mapper, IContratoRepository contratoRepository)
            : base(mapper, contratoRepository)
        {
        }
    }
}
