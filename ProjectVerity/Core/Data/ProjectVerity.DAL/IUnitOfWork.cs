namespace ProjectVerity.DAL
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
