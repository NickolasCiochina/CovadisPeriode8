using DemoCovadis.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Context
{
    public class LeenautoDbContext : DbContext
    {

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<User> Users { get; set; }

        public object User {  get; internal set; }

        public LeenautoDbContext(DbContextOptions<LeenautoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    Name = "User",
                    Email = "user@example.com",
                    Password = "UserPassword"
                });
        }
    }
}