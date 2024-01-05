using DevTestBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevTestBackend.Infrastructure.Persistence.Context
{
    public partial class DbContextTestBackEnd : DbContext
    {
        public DbContextTestBackEnd()
        {
                
        }
        public DbContextTestBackEnd(DbContextOptions<DbContextTestBackEnd> options) : base (options)
        {
                
        }

        public virtual DbSet<Announcement> Announcement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collection", "Modern_Spanish_CI_AS");


            //esa línea de código en Entity Framework Core se utiliza para aplicar las configuraciones de mapeo de entidades (Entity Configurations) 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            OnModelCreatingPartial(modelBuilder);
        }

        //PARTIAL la personalización y extensión del método 
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
