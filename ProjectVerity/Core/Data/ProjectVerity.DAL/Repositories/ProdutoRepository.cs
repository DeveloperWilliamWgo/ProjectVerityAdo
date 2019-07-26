using ProjectVerity.DAL.Extensions;
using ProjectVerity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace ProjectVerity.DAL.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        private readonly DbContext _context;

        public ProdutoRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }

        public IList<Produto> BuscarProdutos()
        {
            using (var command = _context.CreateCommand())
            {
                var produtos = new List<Produto>();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM PRODUTO ORDER BY 1 DESC;";

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    new Produto(reader["COD_PRODUTO"].ToString(), reader["DES_PRODUTO"].ToString(), Convert.ToBoolean(reader["STA_STATUS"]));
                }

                return this.ToList(command).ToList();
            }
        }

        public Produto CriarProduto(Produto user)
        {
            using (var command = _context.CreateCommand())
            {
                command.Parameters.Add(command.CreateParameter("@DES_PRODUTO", user.Descricao));
                command.Parameters.Add(command.CreateParameter("@STA_STATUS", user.Ativo));
                command.Parameters.Add(command.CreateParameter("@COD_PRODUTO", user.ProdutoId));

                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO PRODUTO (COD_PRODUTO, DES_PRODUTO, STA_STATUS)"
                    + "VALUES(@COD_PRODUTO, @DES_PRODUTO, @STA_STATUS);";

                return this.ToList(command).FirstOrDefault();
            }
        }
    }
}
