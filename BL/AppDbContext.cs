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
        
        SeedingStartedTenant(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }
    
    
    private void SeedingStartedTenant(ModelBuilder modelBuilder)
    {
        var list = new List<Tenant>
        {
            new()
            {
                Id = 1,
                Name = "Test tenant 1",
                PhoneNumber = "111 1111 11 11",
                Email = "test.tenant.1@email.domen",
                Password = "test.tenant.1@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test tenant 1",
                Work = "I'm working nowhere",
                Favourite = new List<Property>(),
                Chats = new List<Chat>(),
                Contracts = new List<Contract>(),
                Notifications = new List<Notification>(),
                Reservations = new List<Reservation>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Id = 2,
                Name = "Test tenant 2",
                PhoneNumber = "222 2222 22 22",
                Email = "test.tenant.2@email.domen",
                Password = "test.tenant.2@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test tenant 2",
                Work = "I'm working nowhere",
                Favourite = new List<Property>(),
                Chats = new List<Chat>(),
                Contracts = new List<Contract>(),
                Notifications = new List<Notification>(),
                Reservations = new List<Reservation>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Id = 3,
                Name = "Test tenant 3",
                PhoneNumber = "333 3333 33 33",
                Email = "test.tenant.3@email.domen",
                Password = "test.tenant.3@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test tenant 3",
                Work = "I'm working nowhere",
                Favourite = new List<Property>(),
                Chats = new List<Chat>(),
                Contracts = new List<Contract>(),
                Notifications = new List<Notification>(),
                Reservations = new List<Reservation>(),
                Reviews = new List<Review>()
            }
        };

        modelBuilder.Entity<Tenant>().HasData(list);
    }
}