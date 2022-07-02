using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class ClienteServiceTest : BaseServiceTest<ClienteDTO, Cliente>
    {
        private readonly ClienteDTO cliente;
        private readonly ClienteDTO novoCliente;
        private readonly List<ClienteDTO> listCliente;

        public ClienteServiceTest()
        {
            cliente = new ClienteDTO(1, "Leonardo", "123456789", "031", 123456789);

            novoCliente = new ClienteDTO(1, "Fernanda", "987654321", "011", 987654321);

            listCliente = new List<ClienteDTO>()
            {
                new ClienteDTO(1, "Leonardo", "123456789", "011", 912365489),
                new ClienteDTO(2, "Daniel", "123456789", "021", 965016511),
                new ClienteDTO(3, "Leandro", "123456789", "031", 955646011),
                new ClienteDTO(4, "Matheus", "123456789", "051", 956641360)
            };
        }

        private ClienteService GetBaseService()
        {
            var baseService = new ClienteService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new ClienteRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), cliente);
        }

        [Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, cliente);
            await base.Service_Update_OK(baseService, cliente, novoCliente);
        }

        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), cliente);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), cliente);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), cliente);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), cliente);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listCliente);
        }
    }
}
