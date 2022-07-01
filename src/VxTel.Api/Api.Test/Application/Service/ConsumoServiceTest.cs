using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    [TestClass]
    public class ConsumoServiceTest : BaseServiceTest<ConsumoDTO, Consumo>
    {
        private readonly ConsumoDTO consumo;
        private readonly ConsumoDTO novoConsumo;
        private readonly List<ConsumoDTO> listConsumo;

        public ConsumoServiceTest(IMapper mapper)
            : base (new ConsumoService(mapper, new ConsumoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            consumo = new ConsumoDTO(101, new TimeSpan(0, 11, 20), 2.99);
            novoConsumo = new ConsumoDTO(12, new TimeSpan(5, 30, 20), 19.99);

            listConsumo = new List<ConsumoDTO>()
            {
                new ConsumoDTO(9, new TimeSpan(21, 30, 20), 39.99),
                new ConsumoDTO(11, new TimeSpan(13, 30, 20), 49.99),
                new ConsumoDTO(12, new TimeSpan(11, 30, 20), 59.99),
                new ConsumoDTO(18, new TimeSpan(11, 30, 20), 69.99)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(consumo);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(consumo, novoConsumo);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(consumo);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(consumo);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(consumo);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(consumo);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listConsumo);
        }
    }
}
