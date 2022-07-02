using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class TarifaDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var tarifa = new TarifaDTO(1, "031", "011", 10);

            Assert.Multiple(() =>
            {
                Assert.That(tarifa.Id, Is.EqualTo(1));
                Assert.That(tarifa.DddOrigem, Is.EqualTo("031"));
                Assert.That(tarifa.DddDestino, Is.EqualTo("011"));
                Assert.That(tarifa.Valor, Is.EqualTo(10));
            });
        }
    }
}
