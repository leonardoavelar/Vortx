using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Domain.Mapping;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    public class ProdutoServiceTest : BaseServiceTest<ProdutoDTO, Produto>
    {
        private readonly ProdutoDTO produto;
        private readonly ProdutoDTO novoProduto;
        private readonly List<ProdutoDTO> listProduto;

        public ProdutoServiceTest()
        {
            produto = new ProdutoDTO(1, "Fale Mais 30", new TimeSpan(0, 30, 0), 10, 30.0);

            novoProduto = new ProdutoDTO(1, "Fale Mais 45", new TimeSpan(0, 45, 0), 10, 30.0);

            listProduto = new List<ProdutoDTO>()
            {
                new ProdutoDTO(1, "Fale Mais 30", new TimeSpan(0,30,0), 10, 30.0),
                new ProdutoDTO(2, "Fale Mais 60", new TimeSpan(1,0,0), 10, 60.0),
                new ProdutoDTO(3, "Fale Mais 120", new TimeSpan(2, 0, 0), 10, 120.0)
            };
        }

        private ProdutoService GetBaseService()
        {
            var baseService = new ProdutoService(
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainToDTOMappingProfile()))),
                new ProdutoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync()));

            return baseService;
        }

        [Test]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(GetBaseService(), produto);
        }

        [Test]
        public async Task Service_Update_OK()
        {
            var baseService = GetBaseService();
            await base.Service_Insert_OK(baseService, produto);
            await base.Service_Update_OK(baseService, produto, novoProduto);
        }


        [Test]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(GetBaseService(), produto);
        }

        [Test]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(GetBaseService(), produto);
        }

        [Test]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(GetBaseService(), produto);
        }

        [Test]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(GetBaseService(), produto);
        }

        [Test]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(GetBaseService(), listProduto);
        }
    }
}
