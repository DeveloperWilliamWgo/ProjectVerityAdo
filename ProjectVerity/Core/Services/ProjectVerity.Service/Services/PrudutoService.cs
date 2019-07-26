using System.Collections.Generic;
using ProjectVerity.DAL;
using ProjectVerity.DAL.Config;
using ProjectVerity.DAL.Repositories;
using ProjectVerity.Domain.Entities;
using ProjectVerity.Service.Interfaces;

namespace ProjectVerity.Service.Services
{
    public class PrudutoService : IProdutoService
    {
        private IConnectionFactory connectionFactory;

        public IList<Produto> BuscarProdutos()
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var produtoRep = new ProdutoRepository(context);

            return produtoRep.BuscarProdutos();
        }

        public Produto CriarProduto(Produto produto)
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var userRep = new ProdutoRepository(context);

            return userRep.CriarProduto(produto);
        }
    }
}
