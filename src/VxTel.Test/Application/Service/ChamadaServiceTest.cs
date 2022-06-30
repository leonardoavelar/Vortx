using AutoMapper;
using VxTel.Application.Service;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Domain.Enum;
using VxTel.Infrastructure.Repository;
using VxTel.Test.Integration;

namespace VxTel.Test.Application.Service
{
    [TestClass]
    public class ChamadaServiceTest : BaseServiceTest<ChamadaDTO, Chamada>
    {
        private readonly ChamadaDTO chamada;
        private readonly ChamadaDTO novaChamada;
        private readonly List<ChamadaDTO> listChamada;

        public ChamadaServiceTest(IMapper mapper)
            : base(new ChamadaService(mapper, new ChamadaRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            chamada = new ChamadaDTO(1, "031", 987654321, "011", 123456789, DateTime.Now, SituacaoChamada.NaoAtendida, DateTime.Now, DateTime.Now, new TimeSpan(), 0);

            novaChamada = new ChamadaDTO(1, "021", 987654321, "011", 654915651, DateTime.Now, SituacaoChamada.Encerrada, DateTime.Now, DateTime.Now, new TimeSpan(0, 30, 0), 15);

            listChamada = new List<ChamadaDTO>()
            {
                new ChamadaDTO(16, "031", 987654321, "011", 987654165, DateTime.Now, SituacaoChamada.NaoAtendida, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(12, "031", 987654321, "011", 312156544, DateTime.Now, SituacaoChamada.EmConversa, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(15, "031", 987654321, "011", 156987156, DateTime.Now, SituacaoChamada.Chamando, DateTime.Now, DateTime.Now, new TimeSpan(), 0)
        };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(chamada);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(chamada, novaChamada);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(chamada);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(chamada);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(chamada);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(chamada);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listChamada);
        }
    }
}
