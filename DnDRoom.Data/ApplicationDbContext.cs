using DnDRoom.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnDRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Room> Rooms { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users
            var userModel = modelBuilder.Entity<User>();
            userModel.HasMany<Room>(x => x.Rooms)
                .WithOne(x => x.Owner);

            //Rooms
            var roomModel = modelBuilder.Entity<Room>();
            roomModel.HasKey(x => x.Id);
            roomModel.HasOne<User>(x => x.Owner)
                .WithMany(x => x.Rooms);
            roomModel.Property(x => x.Name);
        }
    }
}