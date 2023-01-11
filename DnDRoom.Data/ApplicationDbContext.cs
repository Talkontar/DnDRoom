using DnDRoom.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnDRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Room_User> room_Users { get; set; }
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

            //Room_User
            var Room_UserModel = modelBuilder.Entity<Room_User>();
            Room_UserModel.HasKey(x => new { x.UserId, x.RoomId });
            //Room_UserModel.HasKey(x => x.Id);
            Room_UserModel.HasOne(x => x.Room)
                .WithMany(r => r.Players)
                .HasForeignKey(x => x.RoomId);
            Room_UserModel.HasOne(x => x.User)
                .WithMany(u => u.ConnectedRooms)
                .HasForeignKey(x => x.UserId);
        }
    }
}