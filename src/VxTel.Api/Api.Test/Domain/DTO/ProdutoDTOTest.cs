using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class ProdutoDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var produto = new ProdutoDTO(1, "Teste", new TimeSpan(1, 30, 0), 10, 100);

            Assert.Multiple(() =>
            {
                Assert.That(produto.Id, Is.EqualTo(1));
                Assert.That(produto.Nome, Is.EqualTo("Teste"));
                Assert.That(produto.TempoContratado.Hours, Is.EqualTo(1));
                Assert.That(produto.TempoContratado.Minutes, Is.EqualTo(30));
                Assert.That(produto.TempoContratado.Seconds, Is.EqualTo(0));
                Assert.That(produto.PercentualAcrescimo, Is.EqualTo(10));
                Assert.That(produto.Valor, Is.EqualTo(100));
            });
        }
    }
}
