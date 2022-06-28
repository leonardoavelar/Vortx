using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class TarifaService : BaseService<Tarifa>, ITarifaService
    {
        public TarifaService(ITarifaRepository tarifaRepository)
            : base(tarifaRepository)
        {
        }
    }
}
