using System.Globalization;
using System.Text.Json;
using Placely.Domain.Entities;

namespace Placely.Application.Models;

public class ReservationModel(
    Reservation reservationEntity, 
    decimal paymentAmount, 
    string paymentFrequency)
{
    public Reservation Entity { get; } = reservationEntity;
    public decimal PaymentAmount { get; } = paymentAmount;
    public string PaymentFrequency { get; } = paymentFrequency;
    public DateTime ContractDate { get; } = DateTime.UtcNow;

    public async Task<Dictionary<string, string>> CreateFieldsAsync(string templatePath)
    {
        var json = await File.ReadAllTextAsync(templatePath);
        var templateFields = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        if (templateFields is null)
            throw new ArgumentException("No fields was found at given file.");

        var newFields = CreateNewFields();

        foreach (var field in ContractField.Fields)
        {
            if (templateFields.ContainsKey(field.Value) 
                && newFields.TryGetValue(field.Value, out var newField))
                templateFields[field.Value] = newField;
        }
        
        return templateFields;
    }

    private Dictionary<string, string> CreateNewFields() => new()
        {
            { ContractField.ContractDate, ContractDate.ToString(CultureInfo.InvariantCulture) },
            { ContractField.LandlordFullname, Entity.Landlord.Tenant.Name},
            { ContractField.LandlordPhoneNumber, Entity.Landlord.Tenant.PhoneNumber},
            { ContractField.LandlordEmail, Entity.Landlord.Tenant.Email},
            { ContractField.LandlordContactAddress, Entity.Landlord.ContactAddress},
            { ContractField.TenantFullname, Entity.Tenant.Name},
            { ContractField.TenantPhoneNumber, Entity.Tenant.PhoneNumber},
            { ContractField.TenantEmail, Entity.Tenant.Email is null or "" ? "нет" : Entity.Tenant.Email},
            { ContractField.PropertyAddress, Entity.Property.Address},
            { ContractField.LeaseStartDateTime, Entity.EntryDate.ToString(CultureInfo.InvariantCulture)},
            { ContractField.LeaseEndDateTime, (Entity.EntryDate + Entity.Duration).ToString(CultureInfo.InvariantCulture)},
            { ContractField.PaymentAmount, PaymentAmount.ToString(CultureInfo.InvariantCulture)},
            { ContractField.PaymentFrequency, PaymentFrequency}
        };
}