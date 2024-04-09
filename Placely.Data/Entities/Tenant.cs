namespace Placely.Data.Entities;

public class Tenant
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarPath { get; set; }
    public long CreationYear { get; set; }
    public string About { get; set; }
    public string Work { get; set; }
    
    public List<Property> Favourite { get; set; }
    public List<Chat> Chats { get; set; }
    public List<Contract> Contracts { get; set; }
    public List<Notification> Notifications { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Review> Reviews { get; set; }
}