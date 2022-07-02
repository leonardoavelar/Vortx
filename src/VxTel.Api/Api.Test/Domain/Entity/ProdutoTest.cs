using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class ProdutoTest
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
            var dto = new ProdutoDTO(1, "Teste", new TimeSpan(1, 30, 0), 10, 100);
            var entity = _mapper.Map<Produto>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.Nome, Is.EqualTo("Teste"));
                Assert.That(entity.TempoContratado.Hours, Is.EqualTo(1));
                Assert.That(entity.TempoContratado.Minutes, Is.EqualTo(30));
                Assert.That(entity.TempoContratado.Seconds, Is.EqualTo(0));
                Assert.That(entity.PercentualAcrescimo, Is.EqualTo(10));
                Assert.That(entity.Valor, Is.EqualTo(100));
            });
        }
    }
}
