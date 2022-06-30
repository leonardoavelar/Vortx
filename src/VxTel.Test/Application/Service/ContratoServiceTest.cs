using AutoMapper;
using VxTel.Application.Service;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Infrastructure.Repository;
using VxTel.Test.Integration;

namespace VxTel.Test.Application.Service
{
    [TestClass]
    public class ContratoServiceTest : BaseServiceTest<ContratoDTO, Contrato>
    {
        private readonly ContratoDTO contrato;
        private readonly ContratoDTO novoContrato;
        private readonly List<ContratoDTO> listContrato;

        public ContratoServiceTest(IMapper mapper)
            : base (new ContratoService(mapper, new ContratoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            contrato = new ContratoDTO(1, 2, DateTime.Now);

            novoContrato = new ContratoDTO(3, 2, DateTime.Now);

            listContrato = new List<ContratoDTO>()
            {
                new ContratoDTO(85, 1, DateTime.Now),
                new ContratoDTO(12, 2, DateTime.Now),
                new ContratoDTO(17, 3, DateTime.Now),
                new ContratoDTO(25, 1, DateTime.Now),
                new ContratoDTO(37, 1, DateTime.Now)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(contrato);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(contrato, novoContrato);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(contrato);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(contrato);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(contrato);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(contrato);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listContrato);
        }
    }
}
