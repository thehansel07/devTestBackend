namespace DevTestBackend.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAnnouncementRepository Annoucenment { get; }
        void SaveChange();
        Task SaveChangesAsync();
    }
}
