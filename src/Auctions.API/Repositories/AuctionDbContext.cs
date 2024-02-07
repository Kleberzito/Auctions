using Auctions.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auctions.API.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=F:\Estudos .NET\Rocketseat\Auctions\data\leilaoDbNLW.db");
            SQLitePCL.Batteries.Init();
        }
    }
}
