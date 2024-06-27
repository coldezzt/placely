namespace Placely.Domain.Entities;

public class PreviousPassword
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public virtual User User { get; set; }
    
    public string Password { get; set; }
}