using Microsoft.EntityFrameworkCore;
using SmartCRM.Models;

namespace SmartCRM.Data {
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Lead> Leads { get; set; }
    public DbSet<FollowUp> FollowUps { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>()
            .Property(s => s.Amount)
            .HasPrecision(18, 2);  // fixes the warning
    }
}
}