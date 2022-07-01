using AutoMapper;
using VxTel.Api.Application.Service;
using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Entity;
using VxTel.Api.Infrastructure.Repository;
using VxTel.Api.Test.Integration;

namespace VxTel.Api.Test.Application.Service
{
    [TestClass]
    public class ProdutoServiceTest : BaseServiceTest<ProdutoDTO, Produto>
    {
        private readonly ProdutoDTO produto;
        private readonly ProdutoDTO novoProduto;
        private readonly List<ProdutoDTO> listProduto;

        public ProdutoServiceTest(IMapper mapper)
            : base(new ProdutoService(mapper, new ProdutoRepository(DatabaseContextExtension.GetDatabaseContextTestAsync())))
        {
            produto = new ProdutoDTO("Fale Mais 30", new TimeSpan(0, 30, 0), 10, 30.0);

            novoProduto = new ProdutoDTO("Fale Mais 45", new TimeSpan(0, 45, 0), 10, 30.0);

            listProduto = new List<ProdutoDTO>()
            {
                new ProdutoDTO("Fale Mais 30", new TimeSpan(0,30,0), 10, 30.0),
                new ProdutoDTO("Fale Mais 60", new TimeSpan(1,0,0), 10, 60.0),
                new ProdutoDTO("Fale Mais 120", new TimeSpan(2, 0, 0), 10, 120.0)
            };
        }

        [TestMethod]
        public async Task Service_Insert_OK()
        {
            await base.Service_Insert_OK(produto);
        }

        [TestMethod]
        public async Task Service_Update_OK()
        {
            await base.Service_Update_OK(produto, novoProduto);
        }

        [TestMethod]
        public async Task Service_Delete_OK()
        {
            await base.Service_Delete_OK(produto);
        }

        [TestMethod]
        public async Task Service_Exists_OK()
        {
            await base.Service_Exists_OK(produto);
        }

        [TestMethod]
        public async Task Service_NoExists_OK()
        {
            await base.Service_NoExists_OK(produto);
        }

        [TestMethod]
        public async Task Service_FindById_OK()
        {
            await base.Service_FindById_OK(produto);
        }

        [TestMethod]
        public async Task Service_FindAll_OK()
        {
            await base.Service_FindAll_OK(listProduto);
        }
    }
}
