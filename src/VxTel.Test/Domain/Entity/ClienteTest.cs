using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Test.Domain.Entity
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
            var dto = new ClienteDTO(1, "Nome", "12345678901");
            var entity = _mapper.Map<Cliente>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("Nome", entity.Nome);
            Assert.AreEqual("12345678901", entity.Documento);
        }
    }
}
