using AutoMapper;
using VxTel.Application.Service;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;
using VxTel.Infrastructure.Repository;
using VxTel.Test.Integration;

namespace VxTel.Test.Application.Service
{
    [TestClass]
    public class TelefoneClienteServiceTest : BaseServiceTest<TelefoneClienteDTO, TelefoneCliente>
    {
        private readonly TelefoneClienteDTO telefoneCliente;
        private readonly TelefoneClienteDTO novoTelefoneCliente;
        private readonly List<TelefoneClienteDTO> listTelefoneCliente;

        public TelefoneClienteServiceTest(IMapper mapper)
            : base (new TelefoneClienteService(mapper, new TelefoneClienteRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            telefoneCliente = new TelefoneClienteDTO(1, "031", 123456789);

            novoTelefoneCliente = new TelefoneClienteDTO(1, "011", 987654321);

            listTelefoneCliente = new List<TelefoneClienteDTO>()
            {
                new TelefoneClienteDTO(1, "011", 912365489),
                new TelefoneClienteDTO(1, "021", 965016511),
                new TelefoneClienteDTO(1, "031", 955646011),
                new TelefoneClienteDTO(1, "051", 956641360)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(telefoneCliente);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(telefoneCliente, novoTelefoneCliente);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(telefoneCliente);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(telefoneCliente);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(telefoneCliente);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(telefoneCliente);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listTelefoneCliente);
        }
    }
}
