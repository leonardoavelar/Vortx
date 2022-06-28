using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ChamadaService : BaseService<Chamada>, IChamadaService
    {
        public ChamadaService(IChamadaRepository chamadaRepository)
            : base(chamadaRepository)
        {
        }
    }
}
