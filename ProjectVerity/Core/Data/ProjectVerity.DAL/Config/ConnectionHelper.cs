namespace ProjectVerity.DAL.Config
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("MinhaConnectionString");
        }
    }
}
