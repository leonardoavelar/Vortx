using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Test.Domain.Entity
{
    [TestClass]
    public class TelefoneClienteTest
    {
        private readonly IMapper _mapper;

        public TelefoneClienteTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var dto = new TelefoneClienteDTO(1, 1002, "031", 123456789);
            var entity = _mapper.Map<TelefoneCliente>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual(1002, entity.ClienteId);
            Assert.AreEqual("031", entity.Ddd);
            Assert.AreEqual(123456789, entity.Telefone);
        }
    }
}
