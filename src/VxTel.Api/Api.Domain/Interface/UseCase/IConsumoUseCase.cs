using System.Threading.Tasks;

namespace VxTel.Api.Domain.Interface.UseCase
{
    public interface IConsumoUseCase
    {
        Task<double> CalcularConsumoTotalClienteAsync(int idClient);
    }
}
