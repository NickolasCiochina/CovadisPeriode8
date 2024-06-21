using DemoCovadis.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Context
{
    public class LeenAutoDbContext : DbContext
    {

        public DbSet<Auto> Auto { get; set; }
        public DbSet<Chauffeur> Chauffeur { get; set; }
        public DbSet<Reservering> Reservering { get; set; }
        public DbSet<User> User { get; set; }
        //public object User { get; internal set; }
        public DbSet<Role> Role { get; set; }

        public LeenAutoDbContext(DbContextOptions<LeenAutoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@example.com",
                    Password = "AdminPassword"
                },

                 new User
                 {
                     Id = 2,
                     Name = "User",
                     Email = "user@example.com",
                     Password = "UserPassword"
                 });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                });
        }
    }
}
