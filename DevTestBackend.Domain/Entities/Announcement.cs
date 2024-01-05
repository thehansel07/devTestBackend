using System.Reflection.Metadata.Ecma335;

namespace DevTestBackend.Domain.Entities
{
    public class Announcement
    {
        public int id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public DateTime AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public DateTime AuditUpdateUser { get; set; }
        public DateTime AuditUpdateDate { get; set; }
        public DateTime AuditDeleteUser { get; set; }
        public DateTime AuditDeleteDate { get; set; }
    }
}
