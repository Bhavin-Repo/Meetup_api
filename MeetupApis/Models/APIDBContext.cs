using Microsoft.EntityFrameworkCore;

namespace MeetupApis.Models
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Profession> Professions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profession>().HasData(
                new Profession
                {
                    Id = 1,
                    Type = "Employed"
                },
                new Profession
                {
                    Id = 2,
                    Type = "Student"
                }
                );
        }
    }
}
