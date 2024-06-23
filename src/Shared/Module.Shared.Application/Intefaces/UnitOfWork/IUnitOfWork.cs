namespace Module.Shared.Application.Intefaces.UnitOfWork
{

    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
        bool HasChanges();
    }
}
