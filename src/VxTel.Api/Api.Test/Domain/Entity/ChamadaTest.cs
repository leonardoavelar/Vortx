using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class ChamadaTest
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile())));
        }

        [Test]
        public void CreateEntity_ValidateSetParameters_OK()
        {
            var date = DateTime.Now;
            var dto = new ChamadaDTO(1, 1001, "031", 123456789, "011", 987654321, date, date, new TimeSpan(1, 30, 0), 123.45);
            var entity = _mapper.Map<Chamada>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.ClienteId, Is.EqualTo(1001));
                Assert.That(entity.DddOrigem, Is.EqualTo("031"));
                Assert.That(entity.TelefoneOrigem, Is.EqualTo(123456789));
                Assert.That(entity.DddDestino, Is.EqualTo("011"));
                Assert.That(entity.TelefoneDestino, Is.EqualTo(987654321));
                Assert.That(entity.DataHoraInicio, Is.EqualTo(date));
                Assert.That(entity.DataHoraFim, Is.EqualTo(date));
                Assert.That(entity.TempoDuracao, Is.Not.Null);
                Assert.That(entity.TempoDuracao.Value.Hours, Is.EqualTo(1));
                Assert.That(entity.TempoDuracao.Value.Minutes, Is.EqualTo(30));
                Assert.That(entity.TempoDuracao.Value.Seconds, Is.EqualTo(0));
                Assert.That(entity.Valor, Is.EqualTo(123.45));
            });
        }
    }
}
