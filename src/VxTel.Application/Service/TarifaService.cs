using VxTel.Domain.Entity;
using VxTel.Domain.Interface.Repository;
using VxTel.Domain.Interface.Service;

namespace VxTel.Application.Service
{
    public sealed class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository TarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            TarifaRepository = tarifaRepository;
        }

        public async Task<Tarifa> InsertAsync(Tarifa entity)
        {
            var result = await TarifaRepository.InsertAsync(entity);
            return result;
        }

        public async Task UpdateAsync(Tarifa entity)
        {
            await TarifaRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await TarifaRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            var result = await TarifaRepository.ExistAsync(id);
            return result;
        }

        public async Task<Tarifa> FindByIdAsync(int id)
        {
            var result = await TarifaRepository.FindByIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<Tarifa>> FindAllAsync()
        {
            var result = await TarifaRepository.FindAllAsync();
            return result;
        }
    }
}
