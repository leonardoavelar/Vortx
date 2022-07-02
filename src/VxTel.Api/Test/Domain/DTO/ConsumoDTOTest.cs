using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class ConsumoDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var consumo = new ConsumoDTO(1, 1001, new TimeSpan(1, 30, 0), 100);

            Assert.Multiple(() =>
            {
                Assert.That(consumo.Id, Is.EqualTo(1));
                Assert.That(consumo.ClienteId, Is.EqualTo(1001));
                Assert.That(consumo.TempoTotal.Hours, Is.EqualTo(1));
                Assert.That(consumo.TempoTotal.Minutes, Is.EqualTo(30));
                Assert.That(consumo.TempoTotal.Seconds, Is.EqualTo(0));
                Assert.That(consumo.Valor, Is.EqualTo(100));
            });
        }
    }
}
