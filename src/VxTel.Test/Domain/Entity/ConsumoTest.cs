using AutoMapper;
using VxTel.Domain.DTO;
using VxTel.Domain.Entity;

namespace VxTel.Test.Domain.Entity
{
    [TestClass]
    public class ConsumoTest
    {
        private readonly IMapper _mapper;

        public ConsumoTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var dto = new ConsumoDTO(1, 1001, new TimeSpan(1, 30, 0), 100);
            var entity = _mapper.Map<Consumo>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual(1001, entity.ClienteId);
            Assert.AreEqual(1, entity.TempoTotal.Hours);
            Assert.AreEqual(30, entity.TempoTotal.Minutes);
            Assert.AreEqual(0, entity.TempoTotal.Seconds);
            Assert.AreEqual(100, entity.Valor);
        }
    }
}
