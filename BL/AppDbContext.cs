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
        modelBuilder.Entity<Property>()
            .HasIndex(p => p.PriceListId)
            .IsUnique(true);
            
        SeedingStartedTenant(modelBuilder);
        SeedingStartedNotifications(modelBuilder);
        SeedingStartedLandlords(modelBuilder);
        SeedingStartedChats(modelBuilder);
        SeedingStartedPriceLists(modelBuilder);
        SeedingStartedPropertyOptions(modelBuilder);
        SeedingStartedProperty(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
    
    
    private static void SeedingStartedTenant(ModelBuilder modelBuilder)
    {
        var l = new List<Tenant>
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
                Work = "I'm working nowhere"
            }, new()
            {
                Id = 2,
                Name = "Test tenant 2",
                PhoneNumber = "222 2222 22 22",
                Email = "test.tenant.2@email.domen",
                Password = "test.tenant.2@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test tenant 2",
                Work = "I'm working nowhere"
            }, new()
            {
                Id = 3,
                Name = "Test tenant 3",
                PhoneNumber = "333 3333 33 33",
                Email = "test.tenant.3@email.domen",
                Password = "test.tenant.3@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test tenant 3",
                Work = "I'm working nowhere"
            }, new()
            {
                Id = 4,
                Name = "Test landlord 1",
                PhoneNumber = "111 1111 11 11",
                Email = "test.landlord.1@email.domen",
                Password = "test.landlord.1@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test landlord 1",
                Work = "I'm working here"
            }, new()
            {
                Id = 5,
                Name = "Test landlord 2",
                PhoneNumber = "222 2222 22 22",
                Email = "test.landlord.2@email.domen",
                Password = "test.landlord.2@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test landlord 2",
                Work = "I'm working here"
            }, new()
            {
                Id = 6,
                Name = "Test landlord 3",
                PhoneNumber = "333 3333 33 33",
                Email = "test.landlord.3@email.domen",
                Password = "test.landlord.3@email.domen",
                AvatarPath = "",
                CreationYear = 2024,
                About = "I'm test landlord 3",
                Work = "I'm working here"
            }
        };

        modelBuilder.Entity<Tenant>().HasData(l);
    }

    private static void SeedingStartedNotifications(ModelBuilder modelBuilder)
    {
        var l = new List<Notification>
        {
            new()
            {
                Id = 1,
                ReceiverId = 2, // tenant
                Title = "Info",
                Content = "This is some helpful information",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = false
            }, new()
            {
                Id = 2,
                ReceiverId = 2, // tenant
                Title = "Info",
                Content = "This is some helpful information",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = false
            }, new()
            {
                Id = 3,
                ReceiverId = 3, // tenant
                Title = "Info",
                Content = "This is already readed some helpful information",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = false
            }, new()
            {
                Id = 4,
                ReceiverId = 3, // tenant
                Title = "Info",
                Content = "This is already readed some helpful information",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = true
            }, new()
            {
                Id = 5,
                ReceiverId = 4, // landlord
                Title = "Request",
                Content = "This is request on reservation",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = false
            }, new()
            {
                Id = 6,
                ReceiverId = 5, // landlord
                Title = "Request",
                Content = "This is readed request on reservation",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsDeleted = true
            }
        };

        modelBuilder.Entity<Notification>().HasData(l);
    }

    private static void SeedingStartedLandlords(ModelBuilder modelBuilder)
    {
        var l = new List<Landlord>
        {
            new()
            {
                Id = 1,
                TenantId = 4,
                ContactAddress = "some address 1"
            }, new()
            {
                Id = 2,
                TenantId = 5,
                ContactAddress = "some address 2"
            }, new()
            {
                Id = 3,
                TenantId = 6,
                ContactAddress = "some address 3"
            }
        };

        modelBuilder.Entity<Landlord>().HasData(l);
    }

    private static void SeedingStartedChats(ModelBuilder modelBuilder)
    {
        var l = new List<Chat>
        {
            new()
            {
                Id = 1,
                TenantId = 1,
                LandlordId = 1,
                DirectoryPath = "/chat-t-1-l-1"
            }, new()
            {
                Id = 2,
                TenantId = 2,
                LandlordId = 1,
                DirectoryPath = "/chat-t-2-l-1"
            }, new()
            {
                Id = 3,
                TenantId = 2,
                LandlordId = 2,
                DirectoryPath = "/chat-t-2-l-2"
            }
        };

        modelBuilder.Entity<Chat>().HasData(l);
    }

    private static void SeedingStartedPriceLists(ModelBuilder modelBuilder)
    {
        var l = new List<PriceList>
        {
            new()
            {
                Id = 1,
                PeriodShort = 1111,
                PeriodMedium = 111,
                PeriodLong = 11
            }, new()
            {
                Id = 2,
                PeriodShort = 2222,
                PeriodMedium = 222,
                PeriodLong = 22
            }, new()
            {
                Id = 3,
                PeriodShort = 3333,
                PeriodMedium = 333,
                PeriodLong = 33
            }
        };

        modelBuilder.Entity<PriceList>().HasData(l);
    }

    private static void SeedingStartedPropertyOptions(ModelBuilder modelBuilder)
    {
        var l = new List<PropertyOption>
        {
            new()
            {
                Id = 1,
                Name = "Option1",
                Value = "Value1"
            }, new()
            {
                Id = 2,
                Name = "Option2",
                Value = "Value2"
            }, new()
            {
                Id = 3,
                Name = "Option3",
                Value = "Value3"
            }
        };

        modelBuilder.Entity<PropertyOption>().HasData(l);
    }
    
    private static void SeedingStartedProperty(ModelBuilder modelBuilder)
    {
        var l = new List<Property>
        {
            new()
            {
                Id = 1,
                OwnerId = 1,
                Type = PropertyType.Flat,
                PriceListId = 1,
                Address = "Flat property address",
                Description = "Flat property description"
            }, new()
            {
                Id = 2,
                OwnerId = 1,
                Type = PropertyType.Hostel,
                PriceListId = 2,
                Address = "Hostel property address",
                Description = "Hostel property description"
            }, new()
            {
                Id = 3,
                OwnerId = 2,
                Type = PropertyType.Villa,
                PriceListId = 3,
                Address = "Villa property address",
                Description = "Villa property description"
            }
        };

        modelBuilder.Entity<Property>().HasData(l);
    }
}