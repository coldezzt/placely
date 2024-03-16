using BL.Configurations;
using BL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BL;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PriceList> Prices => Set<PriceList>();
    public DbSet<PropertyOption> PropertyOptions => Set<PropertyOption>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Landlord> Landlords => Set<Landlord>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<Chat> Chats => Set<Chat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Because EF can't understand which one is referring to another (one-to-one relationship)
        modelBuilder.ApplyConfiguration(new PropertyEntityConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}