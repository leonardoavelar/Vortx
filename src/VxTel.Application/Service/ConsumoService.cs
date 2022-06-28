using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ConsumoService : BaseService<Consumo>, IConsumoService
    {
        public ConsumoService(IConsumoRepository consumoRepository)
            : base(consumoRepository)
        {
        }
    }
}
