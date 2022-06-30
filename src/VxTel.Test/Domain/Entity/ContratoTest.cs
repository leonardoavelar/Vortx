using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Test.Domain.Entity
{
    [TestClass]
    public class ContratoTest
    {
        private readonly IMapper _mapper;

        public ContratoTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var dto = new ContratoDTO(1, 1003, 5000, date);
            var entity = _mapper.Map<Contrato>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual(1003, entity.ClienteId);
            Assert.AreEqual(5000, entity.ProdutoId);
            Assert.AreEqual(date, entity.DataContratacao);
        }
    }
}
