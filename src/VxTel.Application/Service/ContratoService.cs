using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class ContratoService : BaseService<Contrato>, IContratoService
    {
        public ContratoService(IContratoRepository contratoRepository)
            : base(contratoRepository)
        {
        }
    }
}
