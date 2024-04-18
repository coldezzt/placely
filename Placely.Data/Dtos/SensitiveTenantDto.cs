namespace Placely.Data.Dtos;

public class SensitiveTenantDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}