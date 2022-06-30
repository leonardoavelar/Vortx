using AutoMapper;
using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;
using VxTel.Domain.DTO;

namespace VxTel.Application.Service
{
    public sealed class ChamadaService : BaseService<ChamadaDTO, Chamada>, IChamadaService
    {
        public ChamadaService(IMapper mapper, IChamadaRepository chamadaRepository)
            : base(mapper, chamadaRepository)
        {
        }
    }
}
