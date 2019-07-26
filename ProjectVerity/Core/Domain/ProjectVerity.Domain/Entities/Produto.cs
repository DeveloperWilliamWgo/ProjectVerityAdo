using System;

namespace ProjectVerity.Domain.Entities
{
    public class Produto
    {
        public string ProdutoId { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; set; }

        public Produto() { }

        public Produto(string produtoId, string descricao, bool ativo)
        {
            if(!Equals(produtoId, null))
                ProdutoId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4).ToUpper();
            Descricao = descricao;
            Ativo = ativo;
        }

        public void Ativar()
        {
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}
