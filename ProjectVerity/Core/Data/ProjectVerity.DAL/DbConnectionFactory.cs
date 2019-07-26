using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ProjectVerity.DAL
{
    public class DbConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
        private readonly string _name;

        public DbConnectionFactory(string connectionName)
        {
            if (connectionName == null)
                throw new ArgumentNullException("connectionName");

            var connectionString = ConfigurationManager.ConnectionStrings[connectionName];

            if (connectionString == null)
                throw new ConfigurationErrorsException(string.Format("Falha ao encontrar a string de conexão - '{0}' - app/web.config.", connectionName));

            _name = connectionString.ProviderName;
            _provider = DbProviderFactories.GetFactory(connectionString.ProviderName);
            _connectionString = connectionString.ConnectionString;
        }

        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException(string.Format("Falha ao criar conexão usando a connection string - '{0}' - app/web.config.", _name));

            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
