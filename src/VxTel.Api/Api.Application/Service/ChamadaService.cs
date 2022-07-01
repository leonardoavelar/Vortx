using AutoMapper;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Repository;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Application.Service
{
    public sealed class ChamadaService : BaseService<ChamadaDTO, Chamada>, IChamadaService
    {
        public ChamadaService(IMapper mapper, IChamadaRepository chamadaRepository)
            : base(mapper, chamadaRepository)
        {
        }
    }
}
