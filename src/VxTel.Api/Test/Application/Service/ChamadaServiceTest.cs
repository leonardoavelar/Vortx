using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class ChamadaServiceTest : BaseServiceTest<ChamadaDTO, Chamada>
    {
        private readonly ChamadaDTO chamada;
        private readonly ChamadaDTO novaChamada;
        private readonly List<ChamadaDTO> listChamada;

        public ChamadaServiceTest()
        {
            chamada = new ChamadaDTO(1, 1, "031", 987654321, "011", 123456789, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0);

            novaChamada = new ChamadaDTO(1, 1, "021", 987654321, "011", 654915651, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(0, 30, 0), 15);

            listChamada = new List<ChamadaDTO>()
            {
                new ChamadaDTO(1, 16, "031", 987654321, "011", 987654165, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(2, 12, "031", 987654321, "011", 312156544, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0),
                new ChamadaDTO(3, 15, "031", 987654321, "011", 156987156, DateTime.Now, DateTime.Now, DateTime.Now, new TimeSpan(), 0)
        };
        }

        private ChamadaService GetBaseService()
        {
            var baseService = new ChamadaService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new ChamadaRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), chamada);
        }

        [Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, chamada);
            await base.Service_Update_OK(baseService, chamada, novaChamada);
        }

        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), chamada);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), chamada);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), chamada);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), chamada);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listChamada);
        }
    }
}
