using VxTel.Domain.DTO;

namespace VxTel.Test.Domain.DTO
{
    [TestClass]
    public class TarifaDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var tarifa = new TarifaDTO(1, "031", "011", 10);

            Assert.AreEqual(1, tarifa.Id);
            Assert.AreEqual("031", tarifa.DddOrigem);
            Assert.AreEqual("011", tarifa.DddDestino);
            Assert.AreEqual(10, tarifa.Valor);
        }
    }
}
