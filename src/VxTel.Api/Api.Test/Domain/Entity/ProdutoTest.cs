using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Test.Domain.Entity
{
    [TestClass]
    public class ProdutoTest
    {
        private readonly IMapper _mapper;

        public ProdutoTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var dto = new ProdutoDTO(1, "Teste", new TimeSpan(1, 30, 0), 10, 100);
            var entity = _mapper.Map<Produto>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("Teste", entity.Nome);
            Assert.AreEqual(1, entity.TempoContratado.Hours);
            Assert.AreEqual(30, entity.TempoContratado.Minutes);
            Assert.AreEqual(0, entity.TempoContratado.Seconds);
            Assert.AreEqual(10, entity.PercentualAcrescimo);
            Assert.AreEqual(100, entity.Valor);
        }
    }
}
