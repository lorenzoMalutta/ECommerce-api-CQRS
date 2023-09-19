using agrolugue_api.Domain.Model;
using agrolugue_api.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace agrolugue_api.Domain.Data.Context
{
    public class PersistContext : IdentityDbContext<User>
    {
        public PersistContext(DbContextOptions<PersistContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.OwnedProducts)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Rent>()
                .HasOne(p => p.UserRent)
                .WithMany(u => u.RentedProducts)
                .HasForeignKey(p => p.UserRentId);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rent> Rent { get; set; }
    }
}
