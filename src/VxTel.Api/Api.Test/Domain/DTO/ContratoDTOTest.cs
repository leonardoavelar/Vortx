using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class ContratoDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var contrato = new ContratoDTO(1, 1003, 5000, date);

            Assert.Multiple(() =>
            {
                Assert.That(contrato.Id, Is.EqualTo(1));
                Assert.That(contrato.ClienteId, Is.EqualTo(1003));
                Assert.That(contrato.ProdutoId, Is.EqualTo(5000));
                Assert.That(contrato.DataContratacao, Is.EqualTo(date));
            });
        }
    }
}
