using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectVerity.Domain.Entities;
using ProjectVerity.Service.Services;

namespace UnitTestProjectVerity
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestInitialize]
        public void TestInit()
        {
            //Produto produto = new Produto("Papel", true);

            //DeveSerPossivelCriarNovoProduto(produto);
        }

        [TestMethod]
        public void DeveSerPossivelCriarNovoProduto(Produto produto)
        {
            PrudutoService produtoService = new PrudutoService();

            var response = produtoService.CriarProduto(produto);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeveSerPossivelBuscarTodosProduto()
        {
            PrudutoService produtoService = new PrudutoService();

            var response = produtoService.BuscarProdutos();

            Assert.IsNotNull(response);
        }
    }
}
