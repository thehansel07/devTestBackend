using DevTestBackend.Infrastructure.Persistence.Context;
using DevTestBackend.Infrastructure.Persistence.Interfaces;

namespace DevTestBackend.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextTestBackEnd _context;
        public IAnnouncementRepository Annoucenment { get; private set; }
        public UnitOfWork(DbContextTestBackEnd context)
        {
            _context = context;
            Annoucenment = new AnnouncementRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
