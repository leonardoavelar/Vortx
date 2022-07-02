using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Interface.Implementation;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class ContratoServiceTest : BaseServiceTest<ContratoDTO, Contrato>
    {
        private readonly ContratoDTO contrato;
        private readonly ContratoDTO novoContrato;
        private readonly List<ContratoDTO> listContrato;

        public ContratoServiceTest()
        {
            contrato = new ContratoDTO(1, 1, 2, DateTime.Now);

            novoContrato = new ContratoDTO(1, 3, 2, DateTime.Now);

            listContrato = new List<ContratoDTO>()
            {
                new ContratoDTO(1, 85, 1, DateTime.Now),
                new ContratoDTO(2, 12, 2, DateTime.Now),
                new ContratoDTO(3, 17, 3, DateTime.Now),
                new ContratoDTO(4, 25, 1, DateTime.Now),
                new ContratoDTO(5, 37, 1, DateTime.Now)
            };
        }

        private ContratoService GetBaseService()
        {
            var baseService = new ContratoService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new ContratoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), contrato);
        }

        [Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, contrato);
            await base.Service_Update_OK(baseService, contrato, novoContrato);
        }

        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), contrato);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), contrato);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), contrato);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), contrato);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listContrato);
        }
    }
}
