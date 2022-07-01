using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    [TestClass]
    public class TarifaServiceTest : BaseServiceTest<TarifaDTO, Tarifa>
    {
        private readonly TarifaDTO tarifa;
        private readonly TarifaDTO novaTarifa;
        private readonly List<TarifaDTO> listTarifa;

        public TarifaServiceTest(IMapper mapper)
            : base(new TarifaService(mapper, new TarifaRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            tarifa = new TarifaDTO("031", "011", 10);

            novaTarifa = new TarifaDTO("011", "012", 12.5);

            listTarifa = new List<TarifaDTO>()
            {
                new TarifaDTO("021", "011", 8),
                new TarifaDTO("011", "051", 9),
                new TarifaDTO("031", "061", 5)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(tarifa);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(tarifa, novaTarifa);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(tarifa);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(tarifa);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(tarifa);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(tarifa);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listTarifa);
        }
    }
}
