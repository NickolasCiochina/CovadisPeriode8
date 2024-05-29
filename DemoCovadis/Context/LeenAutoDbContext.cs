using DemoCovadis.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCovadis.Context
{
    public class LeenautoDbContext : DbContext
    {

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<User> Users { get; set; }
        public object User { get; internal set; }

        public LeenautoDbContext(DbContextOptions<LeenautoDbContext> options)
           : base(options)
        {
        }
    }
}
