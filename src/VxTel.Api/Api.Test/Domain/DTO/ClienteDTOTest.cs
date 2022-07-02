using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class ClienteDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var cliente = new ClienteDTO(1, "Nome", "12345678901", "011", 987654321);
           
            Assert.Multiple(() =>
            {
                Assert.That(cliente.Id, Is.EqualTo(1));
                Assert.That(cliente.Nome, Is.EqualTo("Nome"));
                Assert.That(cliente.Documento, Is.EqualTo("12345678901"));
                Assert.That(cliente.Ddd, Is.EqualTo("011"));
                Assert.That(cliente.Telefone, Is.EqualTo(987654321));
            });
        }
    }
}
