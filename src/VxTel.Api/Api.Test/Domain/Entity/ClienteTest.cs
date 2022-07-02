using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Test.Domain.Entity
{
    [TestClass]
    public class ClienteTest
    {
        private readonly IMapper _mapper;

        public ClienteTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var dto = new ClienteDTO(1, "Nome", "12345678901", "011", 987654321);
            var entity = _mapper.Map<Cliente>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("Nome", entity.Nome);
            Assert.AreEqual("12345678901", entity.Documento);
            Assert.AreEqual("011", entity.Ddd);
            Assert.AreEqual(987654321, entity.Telefone);
        }
    }
}
