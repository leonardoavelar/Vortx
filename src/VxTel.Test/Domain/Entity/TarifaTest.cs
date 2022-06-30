using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Test.Domain.Entity
{
    [TestClass]
    public class TarifaTest
    {
        private readonly IMapper _mapper;

        public TarifaTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var dto = new TarifaDTO(1, "031", "011", 10);
            var entity = _mapper.Map<Tarifa>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("031", entity.DddOrigem);
            Assert.AreEqual("011", entity.DddDestino);
            Assert.AreEqual(10, entity.Valor);
        }
    }
}
