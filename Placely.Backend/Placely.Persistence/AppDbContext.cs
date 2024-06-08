using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.Persistence.Common.Configuration.EntityConfigurations;

namespace Placely.Persistence;

public class AppDbContext(
    ILogger<AppDbContext> logger, 
    DbContextOptions<AppDbContext> options
    ) : DbContext(options)
{
    #region Database sets
    
    public DbSet<User> Users => Set<User>();
    public DbSet<PreviousPassword> PreviousPasswords => Set<PreviousPassword>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PriceList> Prices => Set<PriceList>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<Chat> Chats => Set<Chat>();
    
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSnakeCaseNamingConvention();
        // TODO: remove
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        logger.Log(LogLevel.Trace, "Begin creating models for AppDbContext.");
        
        #region Entities configuration
        
        modelBuilder.ApplyConfiguration(new PropertyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ContractEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChatEntityConfiguration());

        #endregion
        logger.Log(LogLevel.Trace, "Applied configurations for AppDbContext.");
        
        #region Seeding
        
        SeedingStartedTenant(modelBuilder);
        SeedingStartedNotifications(modelBuilder);
        SeedingStartedChats(modelBuilder);
        SeedingStartedPriceLists(modelBuilder);
        SeedingStartedProperties(modelBuilder);
        SeedingStartedContracts(modelBuilder);
        SeedingStartedReservations(modelBuilder);
        SeedingStartedReviews(modelBuilder);
        SeedingStartedMessages(modelBuilder);
        
        #endregion
        logger.Log(LogLevel.Trace, "Applied seeding for AppDbContext.");

        base.OnModelCreating(modelBuilder);
        logger.Log(LogLevel.Debug, "Successfully created models for AppDbContext.");
    }

    #region Seeding methods

    private static void SeedingStartedTenant(ModelBuilder modelBuilder)
    {
        var l = new List<User>
        {
            new()
            {
                Id = 1,
                Name = "Test tenant 1",
                PhoneNumber = "111 1111 11 11",
                Email = "test.tenant.1@email.domen",
                Password = "test.tenant.1@email.domen",
                About = "I'm test tenant 1",
                Work = "I'm working nowhere",
                UserRole = UserRoleType.Tenant
            }, new()
            {
                Id = 2,
                Name = "Test tenant 2",
                PhoneNumber = "222 2222 22 22",
                Email = "test.tenant.2@email.domen",
                Password = "test.tenant.2@email.domen",
                About = "I'm test tenant 2",
                Work = "I'm working nowhere",
                UserRole = UserRoleType.Tenant
            }, new()
            {
                Id = 3,
                Name = "Test tenant 3",
                PhoneNumber = "333 3333 33 33",
                Email = "test.tenant.3@email.domen",
                Password = "test.tenant.3@email.domen",
                About = "I'm test tenant 3",
                Work = "I'm working nowhere",
                UserRole = UserRoleType.Tenant
            }, new()
            {
                Id = 4,
                Name = "Test landlord 1",
                PhoneNumber = "111 1111 11 11",
                Email = "test.landlord.1@email.domen",
                Password = "test.landlord.1@email.domen",
                About = "I'm test landlord 1",
                Work = "I'm working here",
                UserRole = UserRoleType.Landlord
            }, new()
            {
                Id = 5,
                Name = "Test landlord 2",
                PhoneNumber = "222 2222 22 22",
                Email = "test.landlord.2@email.domen",
                Password = "test.landlord.2@email.domen",
                About = "I'm test landlord 2",
                Work = "I'm working here",
                UserRole = UserRoleType.Landlord
            }, new()
            {
                Id = 6,
                Name = "Test landlord 3",
                PhoneNumber = "333 3333 33 33",
                Email = "test.landlord.3@email.domen",
                Password = "test.landlord.3@email.domen",
                About = "I'm test landlord 3",
                Work = "I'm working here",
                UserRole = UserRoleType.Landlord
            }
        };

        modelBuilder.Entity<User>().HasData(l);
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
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = false
            }, new()
            {
                Id = 2,
                ReceiverId = 2, // tenant
                Title = "Info",
                Content = "This is some helpful information",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = false
            }, new()
            {
                Id = 3,
                ReceiverId = 3, // tenant
                Title = "Info",
                Content = "This is already readed some helpful information",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = false
            }, new()
            {
                Id = 4,
                ReceiverId = 3, // tenant
                Title = "Info",
                Content = "This is already readed some helpful information",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = true
            }, new()
            {
                Id = 5,
                ReceiverId = 4, // landlord
                Title = "Request",
                Content = "This is request on reservation",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = false
            }, new()
            {
                Id = 6,
                ReceiverId = 5, // landlord
                Title = "Request",
                Content = "This is readed request on reservation",
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                IsDeleted = true
            }
        };

        modelBuilder.Entity<Notification>().HasData(l);
    }
    
    private static void SeedingStartedChats(ModelBuilder modelBuilder)
    {
        var l = new List<Chat>
        {
            new()
            {
                Id = 1,
                DirectoryName = "/chat-1-2"
            }, new()
            {
                Id = 2,
                DirectoryName = "/chat-1-3"
            }, new()
            {
                Id = 3,
                DirectoryName = "/chat-2-4"
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
                PeriodLong = 11,
                PropertyId = 1
            }, new()
            {
                Id = 2,
                PeriodShort = 2222,
                PeriodMedium = 222,
                PeriodLong = 22,
                PropertyId = 2
            }, new()
            {
                Id = 3,
                PeriodShort = 3333,
                PeriodMedium = 333,
                PeriodLong = 33,
                PropertyId = 3
            }
        };

        modelBuilder.Entity<PriceList>().HasData(l);
    }
    
    private static void SeedingStartedProperties(ModelBuilder modelBuilder)
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
                Description = "Flat property description",
                PublicationDate = (DateTime.UtcNow - TimeSpan.FromDays(1)).ToUniversalTime()
            }, new()
            {
                Id = 2,
                OwnerId = 1,
                Type = PropertyType.Hostel,
                PriceListId = 2,
                Address = "Hostel property address",
                Description = "Hostel property description",
                PublicationDate = (DateTime.UtcNow - TimeSpan.FromDays(30)).ToUniversalTime()
            }, new()
            {
                Id = 3,
                OwnerId = 2,
                Type = PropertyType.Villa,
                PriceListId = 3,
                Address = "Villa property address",
                Description = "Villa property description",
                PublicationDate = (DateTime.UtcNow - TimeSpan.FromDays(60)).ToUniversalTime()
            }
        };

        modelBuilder.Entity<Property>().HasData(l);
    }

    private static void SeedingStartedContracts(ModelBuilder modelBuilder)
    {
        var l = new List<Contract>
        {
            new()
            {
                Id = 1,
                ReservationId = 1,
            },
            new()
            {
                Id = 2,
                ReservationId = 2,
            },
            new()
            {
                Id = 3,
                ReservationId = 3,
            }
        };

        modelBuilder.Entity<Contract>().HasData(l);
    }

    private static void SeedingStartedReservations(ModelBuilder modelBuilder)
    {
        var l = new List<Reservation>
        {
            new ()
            {
                Id = 1,
                PropertyId = 1,
                StatusType = ReservationStatusType.Approved,
                CreationDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(20)),
                Duration = TimeSpan.FromDays(37),
                EntryDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(7)).ToUniversalTime(),
                GuestsAmount = 3,
                PaymentAmount = 250_000,
                PaymentFrequency = "2 раза в год"
                
            }, new ()
            {
                Id = 2,
                // TenantId = 2,
                // LandlordId = 1,
                PropertyId = 2,
                StatusType = ReservationStatusType.Approved,
                CreationDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)),
                Duration = TimeSpan.FromDays(14),
                EntryDate = DateTime.UtcNow,
                GuestsAmount = 1,
                PaymentAmount = 3000,
                PaymentFrequency = "2 раза в неделю"
            }, new ()
            {
                Id = 3,
                // TenantId = 3,
                // LandlordId = 2,
                PropertyId = 3,
                StatusType = ReservationStatusType.Approved,
                CreationDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(3)),
                Duration = TimeSpan.FromDays(3),
                EntryDate = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)).ToUniversalTime(),
                GuestsAmount = 2,
                PaymentAmount = 40000,
                PaymentFrequency = "1 раз в месяц"
            }, new()
            {
                Id = 4,
                // TenantId = 1,
                // LandlordId = 1,
                PropertyId = 2,
                StatusType = ReservationStatusType.Opened,
                CreationDateTime = DateTime.UtcNow,
                Duration = TimeSpan.FromDays(10),
                EntryDate = DateTime.UtcNow.Add(TimeSpan.FromDays(4)),
                GuestsAmount = 3
            }, new()
            {
                Id = 5,
                // TenantId = 3,
                // LandlordId = 2,
                PropertyId = 3,
                StatusType = ReservationStatusType.Declined,
                DeclineReason = "too many guests",
                CreationDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(10)),
                Duration = TimeSpan.FromDays(10),
                EntryDate = DateTime.UtcNow.Add(TimeSpan.FromDays(4)),
                GuestsAmount = 34
            }, new()
            {
                Id = 6,
                // TenantId = 1,
                // LandlordId = 2,
                PropertyId = 3,
                StatusType = ReservationStatusType.InProgress,
                CreationDateTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(10)),
                Duration = TimeSpan.FromDays(10),
                EntryDate = DateTime.UtcNow.Add(TimeSpan.FromDays(4)),
                GuestsAmount = 2
            }
        };

        modelBuilder.Entity<Reservation>().HasData(l);
    }

    private static void SeedingStartedReviews(ModelBuilder modelBuilder)
    {
        var l = new List<Review>
        {
            new()
            {
                Id = 1,
                AuthorId = 1,
                PropertyId = 1,
                Rating = 1,
                Content = "review 1",
                Date = DateTime.UtcNow
            }, new()
            {
                Id = 2,
                AuthorId = 2,
                PropertyId = 2,
                Rating = 2,
                Content = "review 2",
                Date = DateTime.UtcNow
            }, new()
            {
                Id = 3,
                AuthorId = 3,
                PropertyId = 3,
                Rating = 3,
                Content = "review 3",
                Date = DateTime.UtcNow
            }, new()
            {
                Id = 4,
                AuthorId = 4,
                PropertyId = 1,
                Rating = 4,
                Content = "review 4",
                Date = DateTime.UtcNow
            }, new()
            {
                Id = 5,
                AuthorId = 5,
                PropertyId = 2,
                Rating = 5,
                Content = "review 5",
                Date = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<Review>().HasData(l);
    }

    private static void SeedingStartedMessages(ModelBuilder modelBuilder)
    {
        var l = new List<Message>
        {
            new()
            {
                Id = 1,
                ChatId = 1,
                AuthorId = 1,
                Content = "message 1",
                Date = DateTime.UtcNow.Subtract(TimeSpan.FromDays(2)).ToUniversalTime(),
                FileName = ""
            }, new()
            {
                Id = 2,
                ChatId = 1,
                AuthorId = 4,
                Content = "message 2",
                Date = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)).ToUniversalTime(),
                FileName = ""
            }, new()
            {
                Id = 3,
                ChatId = 2,
                AuthorId = 2,
                Content = "message with file",
                Date = DateTime.UtcNow.Subtract(TimeSpan.FromDays(6)).ToUniversalTime(),
                FileName = "smt.txt"
            }
        };

        modelBuilder.Entity<Message>().HasData(l);
    }
    
    #endregion
}