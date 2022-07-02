using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    [TestClass]
    public class ClienteDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var cliente = new ClienteDTO(1, "Nome", "12345678901", "011", 987654321);

            Assert.AreEqual(1, cliente.Id);
            Assert.AreEqual("Nome", cliente.Nome);
            Assert.AreEqual("12345678901", cliente.Documento);
            Assert.AreEqual("011", cliente.Ddd);
            Assert.AreEqual(987654321, cliente.Telefone);
        }
    }
}
