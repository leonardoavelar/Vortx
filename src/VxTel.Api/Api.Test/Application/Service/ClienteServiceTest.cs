using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    [TestClass]
    public class ClienteServiceTest : BaseServiceTest<ClienteDTO, Cliente>
    {
        private readonly ClienteDTO cliente;
        private readonly ClienteDTO novoCliente;
        private readonly List<ClienteDTO> listCliente;

        public ClienteServiceTest(IMapper mapper)
            : base (new ClienteService(mapper, new ClienteRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            cliente = new ClienteDTO("Leonardo", "123456789", "031", 123456789);

            novoCliente = new ClienteDTO("Fernanda", "987654321", "011", 987654321);

            listCliente = new List<ClienteDTO>()
            {
                new ClienteDTO("Leonardo", "123456789", "011", 912365489),
                new ClienteDTO("Daniel", "123456789", "021", 965016511),
                new ClienteDTO("Leandro", "123456789", "031", 955646011),
                new ClienteDTO("Matheus", "123456789", "051", 956641360)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(cliente);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(cliente, novoCliente);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(cliente);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(cliente);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(cliente);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(cliente);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listCliente);
        }
    }
}
