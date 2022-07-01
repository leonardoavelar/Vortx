using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    [TestClass]
    public class ContratoDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var contrato = new ContratoDTO(1, 1003, 5000, date);

            Assert.AreEqual(1, contrato.Id);
            Assert.AreEqual(1003, contrato.ClienteId);
            Assert.AreEqual(5000, contrato.ProdutoId);
            Assert.AreEqual(date, contrato.DataContratacao);
        }
    }
}
