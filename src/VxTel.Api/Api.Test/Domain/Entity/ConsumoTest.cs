using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class ConsumoTest
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
            var dto = new ConsumoDTO(1, 1001, new TimeSpan(1, 30, 0), 100);
            var entity = _mapper.Map<Consumo>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.ClienteId, Is.EqualTo(1001));
                Assert.That(entity.TempoTotal.Hours, Is.EqualTo(1));
                Assert.That(entity.TempoTotal.Minutes, Is.EqualTo(30));
                Assert.That(entity.TempoTotal.Seconds, Is.EqualTo(0));
                Assert.That(entity.Valor, Is.EqualTo(100));
            });
        }
    }
}
