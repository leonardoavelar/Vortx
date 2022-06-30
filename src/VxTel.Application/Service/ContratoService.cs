using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ContratoService : BaseService<ContratoDTO, Contrato>, IContratoService
    {
        public ContratoService(IMapper mapper, IContratoRepository contratoRepository)
            : base(mapper, contratoRepository)
        {
        }
    }
}
