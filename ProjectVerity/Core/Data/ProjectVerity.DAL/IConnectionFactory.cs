using System.Data;

namespace ProjectVerity.DAL
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
