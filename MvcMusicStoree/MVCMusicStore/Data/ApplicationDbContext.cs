using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;
using MVCMusicStore.Models;

namespace MVCMusicStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MvcMusicStore.Models.Album>? Album { get; set; }
        public DbSet<MvcMusicStore.Models.Artist>? Artist { get; set; }
        public DbSet<MvcMusicStore.Models.Genre>? Genre { get; set; }        
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        
    }
}