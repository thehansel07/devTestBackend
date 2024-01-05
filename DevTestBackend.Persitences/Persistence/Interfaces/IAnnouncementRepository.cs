using DevTestBackend.Domain.Entities;
using DevTestBackend.Infrastructure.Commons.Bases.Request;
using DevTestBackend.Infrastructure.Commons.Bases.Response;

namespace DevTestBackend.Infrastructure.Persistence.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<BaseEntityResponse<Announcement>> ListAnnouncement(BaseFilterRequest filters);
        Task<List<Announcement>> FecthAnnoucenmentFromBitmex();
        Task<Announcement> AnnouncementById(int id);
        Task<bool> RegisterAnnouncement(Announcement announcement);
        Task<bool> EditAnnouncement(Announcement announcement);
        Task<bool> RemoveAnnouncement(int id);
    }
}
