using Microsoft.EntityFrameworkCore;
 
namespace Auction.Models
{
    public class AuctionContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}