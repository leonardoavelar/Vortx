using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    [TestClass]
    public class ConsumoDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var consumo = new ConsumoDTO(1, 1001, new TimeSpan(1, 30, 0), 100);

            Assert.AreEqual(1, consumo.Id);
            Assert.AreEqual(1001, consumo.ClienteId);
            Assert.AreEqual(1, consumo.TempoTotal.Hours);
            Assert.AreEqual(30, consumo.TempoTotal.Minutes);
            Assert.AreEqual(0, consumo.TempoTotal.Seconds);
            Assert.AreEqual(100, consumo.Valor);
        }
    }
}
