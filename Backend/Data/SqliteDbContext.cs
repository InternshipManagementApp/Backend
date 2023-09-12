using Backend.Data.Model;
using Backend.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Road> Roads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "internshipManagmentDatabase");
            modelBuilder.Entity<User>(
                entity => entity.HasKey(k => k.UserId));

            modelBuilder.Entity<Room>().ToTable("Room", "internshipManagmentDatabase");
            modelBuilder.Entity<Room>(
                entity => entity.HasKey(k => k.RoomId));

            modelBuilder.Entity<Road>().ToTable("Road", "internshipManagmentDatabase");
            modelBuilder.Entity<Road>(
                entity => entity.HasKey(k => k.RoadId));

            modelBuilder.Entity<Road>()
               .HasOne(c => c.Room)
               .WithMany(b => b.Roads)
               .HasForeignKey(a => a.RoomId);

            modelBuilder.Entity<Road>()
               .HasOne(c => c.User)
               .WithMany(b => b.Roads)
               .HasForeignKey(a => a.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
