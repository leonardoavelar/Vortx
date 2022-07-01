using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    [TestClass]
    public class ProdutoDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var produto = new ProdutoDTO(1, "Teste", new TimeSpan(1, 30, 0), 10, 100);

            Assert.AreEqual(1, produto.Id);
            Assert.AreEqual("Teste", produto.Nome);
            Assert.AreEqual(1, produto.TempoContratado.Hours);
            Assert.AreEqual(30, produto.TempoContratado.Minutes);
            Assert.AreEqual(0, produto.TempoContratado.Seconds);
            Assert.AreEqual(10, produto.PercentualAcrescimo);
            Assert.AreEqual(100, produto.Valor);
        }
    }
}
