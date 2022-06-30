using VxTel.Domain.DTO;

namespace VxTel.Test.Domain.DTO
{
    [TestClass]
    public class TelefoneClienteDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var telefoneCliente = new TelefoneClienteDTO(1, 1002, "031", 123456789);

            Assert.AreEqual(1, telefoneCliente.Id);
            Assert.AreEqual(1002, telefoneCliente.ClienteId);
            Assert.AreEqual("031", telefoneCliente.Ddd);
            Assert.AreEqual(123456789, telefoneCliente.Telefone);
        }
    }
}
