using DevTestBackend.Domain.Entities;
using DevTestBackend.Infrastructure.Commons.Bases.Request;
using DevTestBackend.Infrastructure.Commons.Bases.Response;
using DevTestBackend.Infrastructure.Persistence.Context;
using DevTestBackend.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DevTestBackend.Infrastructure.Persistence.Repositories
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        public readonly string _baseUrl;

        private readonly IConfiguration _configuration;

        private readonly DbContextTestBackEnd _context;

        public AnnouncementRepository(DbContextTestBackEnd context)
        {
            _context = context;
                
        }

        public async Task<BaseEntityResponse<Announcement>> ListAnnouncement(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Announcement>();

            var announcement = _context.Announcement.AsNoTracking().AsQueryable();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        announcement = announcement.Where(x => x.title.Contains(filters.TextFilter));
                        break;
                    case 2:
                        announcement = announcement.Where(x => x.link.Contains(filters.TextFilter));
                        break;

                    case 3:
                        announcement = announcement.Where(x => x.content.Contains(filters.TextFilter));
                        break;


                }

            }
            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                announcement = announcement.Where(x => x.date >= Convert.ToDateTime(filters.StartDate) && x.date <= Convert.ToDateTime(filters.EndDate));

            }

            if (filters.Sort is null) filters.Sort = "id";

            response.TotalRecords = await announcement.CountAsync();
            response.Items = await Ordering(filters, announcement).ToListAsync();

            return response;

        }

        public async Task<Announcement> AnnouncementById(int id)
        {
            var announcement = await _context.Announcement.AsNoTracking().FirstOrDefaultAsync(x=> x.id.Equals(id));
            return announcement;
        }


        public async Task<bool> EditAnnouncement(Announcement announcement)
        {
            //announcement.AuditUpdateDate = 1;
            announcement.AuditUpdateDate = DateTime.Now;

            _context.Update(announcement);
            _context.Entry(announcement).Property(x => x.AuditCreateUser).IsModified = false;
            _context.Entry(announcement).Property(x => x.AuditCreateDate).IsModified = false;

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<List<Announcement>> FecthAnnoucenmentFromBitmex()
        {
            List<Announcement> list = new List<Announcement>();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("https://www.bitmex.com/api/v1/announcement");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Announcement>>(jsonResponse);
                    list = result!;

                }
            }
            catch (Exception ex)
            {

                throw;
            }



            return list;
        }

       
        public async Task<bool> RegisterAnnouncement(Announcement announcement)
        {
            await _context.AddAsync(announcement);

            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<bool> RemoveAnnouncement(int id)
        {
            var announcement = await _context.Announcement.AsNoTracking().SingleOrDefaultAsync(x => x.id.Equals(id));


            //announcement.AuditDeleteUser = 1;
            announcement.AuditDeleteDate = DateTime.Now;

            _context.Update(announcement);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;

        }
    }
}
