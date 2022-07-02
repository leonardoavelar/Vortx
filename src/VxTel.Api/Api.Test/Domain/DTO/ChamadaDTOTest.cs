using VxTel.Api.Domain.DTO;

namespace VxTel.Api.Test.Domain.DTO
{
    public class ChamadaDTOTest
    {
        [Test]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var chamada = new ChamadaDTO(1, 1001, "031", 123456789, "011", 987654321, date, date, date, new TimeSpan(1, 30, 0), 123.45);
            
            Assert.Multiple(() =>
            {
                Assert.That(chamada.Id, Is.EqualTo(1));
                Assert.That(chamada.ClienteId, Is.EqualTo(1001));
                Assert.That(chamada.DddOrigem, Is.EqualTo("031"));
                Assert.That(chamada.TelefoneOrigem, Is.EqualTo(123456789));
                Assert.That(chamada.DddDestino, Is.EqualTo("011"));
                Assert.That(chamada.TelefoneDestino, Is.EqualTo(987654321));
                Assert.That(chamada.DataChamada, Is.EqualTo(date));
                Assert.That(chamada.DataHoraInicio, Is.EqualTo(date));
                Assert.That(chamada.DataHoraFim, Is.EqualTo(date));
                Assert.That(chamada.TempoDuracao, Is.Not.Null);
                Assert.That(chamada.TempoDuracao.Value.Hours, Is.EqualTo(1));
                Assert.That(chamada.TempoDuracao.Value.Minutes, Is.EqualTo(30));
                Assert.That(chamada.TempoDuracao.Value.Seconds, Is.EqualTo(0));
                Assert.That(chamada.Valor, Is.EqualTo(123.45));
            });
        }
    }
}
