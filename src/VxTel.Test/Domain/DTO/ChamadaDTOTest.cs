using VxTel.Domain.DTO;
using VxTel.Domain.Enum;

namespace VxTel.Test.Domain.DTO
{
    [TestClass]
    public class ChamadaDTOTest
    {
        [TestMethod]
        public void CreateDTO_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;

            var chamada = new ChamadaDTO(1, 1001, "031", 123456789, "011", 987654321, date, SituacaoChamada.Chamando, date, date, new TimeSpan(1, 30, 0), 123.45);

            Assert.AreEqual(1, chamada.Id);
            Assert.AreEqual(1001, chamada.ClienteId);
            Assert.AreEqual("031", chamada.DddOrigem);
            Assert.AreEqual(123456789, chamada.TelefoneOrigem);
            Assert.AreEqual("011", chamada.DddDestino);
            Assert.AreEqual(987654321, chamada.TelefoneDestino);
            Assert.AreEqual(date, chamada.DataChamada);
            Assert.AreEqual(SituacaoChamada.Chamando, chamada.Situacao);
            Assert.AreEqual(date, chamada.DataHoraInicio);
            Assert.AreEqual(date, chamada.DataHoraFim);
            Assert.IsNotNull(chamada.TempoDuracao);
            Assert.AreEqual(1, chamada.TempoDuracao.Value.Hours);
            Assert.AreEqual(30, chamada.TempoDuracao.Value.Minutes);
            Assert.AreEqual(0, chamada.TempoDuracao.Value.Seconds);
            Assert.AreEqual(123.45, chamada.Valor);
        }
    }
}
