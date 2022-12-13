using Microsoft.EntityFrameworkCore;

namespace MusicList.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename= ./Songs.sqlite");
        }

        public DbSet<Song> Songs { get; set; }
    }
}
