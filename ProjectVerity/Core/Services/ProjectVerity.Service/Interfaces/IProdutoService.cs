using ProjectVerity.Domain.Entities;
using System.Collections.Generic;

namespace ProjectVerity.Service.Interfaces
{
    public interface IProdutoService
    {
        IList<Produto> BuscarProdutos();
        Produto CriarProduto(Produto user);
    }
}
