using Placely.Data.Abstractions;
using Placely.Data.Models;

namespace Placely.Data.Entities;

public class Tenant : IEntity
{
    public long Id { get; set; }
    public UserRole UserRole { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    public string Password { get; set; }
    public virtual List<PreviousPassword>? PreviousPasswords { get; set; }

    public string? AvatarPath { get; set; }
    public string? About { get; set; }
    public string? Work { get; set; }
    
    public virtual List<Property> Favourite { get; set; }
    public virtual List<Chat> Chats { get; set; }
    public virtual List<Contract> Contracts { get; set; }
    public virtual List<Notification> Notifications { get; set; }
    public virtual List<Reservation> Reservations { get; set; }
    public virtual List<Review> Reviews { get; set; }
}