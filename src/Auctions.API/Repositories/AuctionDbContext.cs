using Auctions.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=F:\Estudos .NET\Rocketseat\Auctions\data\leilaoDbNLW.db");            
        }
    }
}
