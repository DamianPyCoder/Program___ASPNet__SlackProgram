using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<TypingNotification> TypingNotification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Channel>()
                .HasData(new Channel {
                    Id = Guid.NewGuid(),
                    Name = "DotNetCore",
                    Description = "Canal dedicado a dotnet core"
                },
                new Channel {
                    Id = Guid.NewGuid(),
                    Name = "Angular",
                    Description = "Canal dedicado a Angular"
                },
                new Channel {
                    Id = Guid.NewGuid(),
                    Name = "Reactjs",
                    Description = "Canal dedicado a ReactJs"
                });

            modelBuilder
                .Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.SenderId);
            modelBuilder
                .Entity<AppUser>()
                .HasOne(a => a.TypingNotification)
                .WithOne(b => b.Sender)
                .HasForeignKey<TypingNotification>(b => b.Id);
        }
    }
}
