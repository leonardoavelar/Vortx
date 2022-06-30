using System.Threading.Tasks;

namespace VxTel.Domain.Interface.UseCase
{
    public interface IConsumoUseCase
    {
        Task<double> CalcularConsumoTotalCliente(int idClient);
    }
}
