using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class ConsumoServiceTest : BaseServiceTest<ConsumoDTO, Consumo>
    {
        private readonly ConsumoDTO consumo;
        private readonly ConsumoDTO novoConsumo;
        private readonly List<ConsumoDTO> listConsumo;

        public ConsumoServiceTest()
        {
            consumo = new ConsumoDTO(1, 101, new TimeSpan(0, 11, 20), 2.99);
            novoConsumo = new ConsumoDTO(1, 12, new TimeSpan(5, 30, 20), 19.99);

            listConsumo = new List<ConsumoDTO>()
            {
                new ConsumoDTO(1, 9, new TimeSpan(21, 30, 20), 39.99),
                new ConsumoDTO(2, 11, new TimeSpan(13, 30, 20), 49.99),
                new ConsumoDTO(3, 12, new TimeSpan(11, 30, 20), 59.99),
                new ConsumoDTO(4, 18, new TimeSpan(11, 30, 20), 69.99)
            };
        }

        private ConsumoService GetBaseService()
        {
            var baseService = new ConsumoService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new ConsumoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), consumo);
        }

        //[Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, consumo);
            await base.Service_Update_OK(baseService, consumo, novoConsumo);
        }

        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), consumo);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), consumo);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), consumo);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), consumo);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listConsumo);
        }
    }
}
