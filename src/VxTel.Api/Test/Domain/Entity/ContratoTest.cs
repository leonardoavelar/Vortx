using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class ContratoTest
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
            var dto = new ContratoDTO(1, 1003, 5000, date);
            var entity = _mapper.Map<Contrato>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.ClienteId, Is.EqualTo(1003));
                Assert.That(entity.ProdutoId, Is.EqualTo(5000));
                Assert.That(entity.DataContratacao, Is.EqualTo(date));
            });
        }
    }
}
