using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;

namespace VxTel.Api.Test.Domain.Entity
{
    [TestClass]
    public class ChamadaTest
    {
        private readonly IMapper _mapper;

        public ChamadaTest(IMapper mapper)
        {
            _mapper = mapper;
        }

        [TestMethod]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var dto = new ChamadaDTO(1, 1001, "031", 123456789, "011", 987654321, date, date, date, new TimeSpan(1, 30, 0), 123.45);
            var entity = _mapper.Map<Chamada>(dto);

            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual(1001, entity.ClienteId);
            Assert.AreEqual("031", entity.DddOrigem);
            Assert.AreEqual(123456789, entity.TelefoneOrigem);
            Assert.AreEqual("011", entity.DddDestino);
            Assert.AreEqual(987654321, entity.TelefoneDestino);
            Assert.AreEqual(date, entity.DataChamada);
            Assert.AreEqual(date, entity.DataHoraInicio);
            Assert.AreEqual(date, entity.DataHoraFim);
            Assert.IsNotNull(entity.TempoDuracao);
            Assert.AreEqual(1, entity.TempoDuracao.Value.Hours);
            Assert.AreEqual(30, entity.TempoDuracao.Value.Minutes);
            Assert.AreEqual(0, entity.TempoDuracao.Value.Seconds);
            Assert.AreEqual(123.45, entity.Valor);
        }
    }
}
