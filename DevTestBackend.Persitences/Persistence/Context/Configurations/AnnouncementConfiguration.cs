using DevTestBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTestBackend.Infrastructure.Persistence.Context.Configurations
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(e => e.id).HasName("PK__Announce__3213E83F9523A9F8");

            builder.Property(e => e.link)
          .HasMaxLength(100)
          .IsUnicode(false);

            builder.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.content)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.date)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
