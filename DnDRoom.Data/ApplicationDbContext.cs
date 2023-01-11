using DnDRoom.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnDRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Character> Characters { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users
            var userModel = modelBuilder.Entity<User>();
            

            //Rooms
            var roomModel = modelBuilder.Entity<Room>();
            roomModel.HasKey(x => x.Id);
            roomModel.HasOne<User>(r => r.Owner)
                .WithMany(u => u.CreatedRooms)
                .HasForeignKey(r => r.OwnerId);
            roomModel.Property(x => x.Name);

            //Characters
            var characterModel = modelBuilder.Entity<Character>();
            characterModel.HasKey(c => c.Id);
            characterModel.Property(c => c.Name);
            characterModel.HasOne<User>(c => c.Owner)
                .WithMany(u => u.CreatedCharacters)
                .HasForeignKey(c => c.OwnerId);
            characterModel.HasOne<Room>(c => c.Room)
                .WithMany(r => r.PlayerCharacters)
                .HasForeignKey(c => c.RoomId);
        }
    }
}