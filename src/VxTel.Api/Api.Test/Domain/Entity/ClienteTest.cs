using AutoMapper;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;

namespace VxTel.Api.Test.Domain.Entity
{
    public class ClienteTest
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
            var dto = new ClienteDTO(1, "Nome", "12345678901", "011", 987654321);
            var entity = _mapper.Map<Cliente>(dto);

            Assert.Multiple(() =>
            {
                Assert.That(entity.Id, Is.EqualTo(1));
                Assert.That(entity.Nome, Is.EqualTo("Nome"));
                Assert.That(entity.Documento, Is.EqualTo("12345678901"));
                Assert.That(entity.Ddd, Is.EqualTo("011"));
                Assert.That(entity.Telefone, Is.EqualTo(987654321));
            });
        }
    }
}
