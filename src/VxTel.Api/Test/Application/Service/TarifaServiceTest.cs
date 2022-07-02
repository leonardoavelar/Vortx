using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class TarifaServiceTest : BaseServiceTest<TarifaDTO, Tarifa>
    {
        private readonly TarifaDTO tarifa;
        private readonly TarifaDTO novaTarifa;
        private readonly List<TarifaDTO> listTarifa;

        public TarifaServiceTest()
        {
            tarifa = new TarifaDTO(1, "031", "011", 10);

            novaTarifa = new TarifaDTO(1, "011", "012", 12.5);

            listTarifa = new List<TarifaDTO>()
            {
                new TarifaDTO(1, "021", "011", 8),
                new TarifaDTO(2, "011", "051", 9),
                new TarifaDTO(3, "031", "061", 5)
            };
        }

        private TarifaService GetBaseService()
        {
            var baseService = new TarifaService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new TarifaRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), tarifa);
        }

        [Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, tarifa);
            await base.Service_Update_OK(baseService, tarifa, novaTarifa);
        }

        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), tarifa);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), tarifa);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), tarifa);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), tarifa);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listTarifa);
        }
    }
}
