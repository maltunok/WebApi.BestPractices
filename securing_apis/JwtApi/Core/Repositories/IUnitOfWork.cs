namespace JwtApi.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
