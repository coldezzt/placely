using Placely.Domain.Common.Enums;
using Placely.Domain.Interfaces.Entities;

namespace Placely.Domain.Entities;

public class User : IEntity
{
    public long Id { get; set; }
    
    public required UserRoleType UserRole { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    public virtual List<PreviousPassword>? PreviousPasswords { get; set; }

    public string? About { get; set; }
    public string? Work { get; set; }
    public string? ContactAddress { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpirationDate { get; set; }

    public bool IsAdditionalRegistrationRequired { get; set; }
    public bool IsTwoFactorEnabled { get; set; }
    public string? ManualEntryKey { get; set; }
    public string? QrImageUrl { get; set; }
    public string? TwoFactorAccountSecretKey { get; set; }
    
    
    public virtual List<Property> OwnedProperties { get; set; }
    public virtual List<Property> Favourites { get; set; }
    public virtual List<Chat> Chats { get; set; }
    public virtual List<Message> Messages { get; set; }
    public virtual List<Notification> Notifications { get; set; }
    public virtual List<Reservation> Reservations { get; set; }
    public virtual List<Review> Reviews { get; set; }
}