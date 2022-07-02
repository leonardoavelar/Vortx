using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class TarifaTest
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
            var dto = new TarifaDTO(1, "031", "011", 10);
            var entity = _mapper.Map<Tarifa>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.DddOrigem, Is.EqualTo("031"));
                Assert.That(entity.DddDestino, Is.EqualTo("011"));
                Assert.That(entity.Valor, Is.EqualTo(10));
            });
        }
    }
}
