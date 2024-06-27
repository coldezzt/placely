using System.Globalization;
using System.Text.Json;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;

namespace Placely.Application.Common.Models;

public class ReservationModel
{
    public ReservationModel(Reservation reservationEntity, 
        decimal paymentAmount, 
        string paymentFrequency)
    {
        Entity = reservationEntity;
        PaymentAmount = paymentAmount;
        PaymentFrequency = paymentFrequency;
        ContractDate = DateTime.UtcNow;
        Tenant = Entity.Participants.First(u => u.UserRole == UserRoleType.Tenant);
        Landlord = Entity.Participants.First(u => u.UserRole == UserRoleType.Landlord);
    }

    public Reservation Entity { get; }
    public decimal PaymentAmount { get; }
    public string PaymentFrequency { get; }
    public User Tenant { get; set; }
    public User Landlord { get; set; }
    public DateTime ContractDate { get; }

    public async Task<Dictionary<string, string>> CreateFieldsAsync(string templatePath)
    {
        var json = await File.ReadAllTextAsync(templatePath);
        var templateFields = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        if (templateFields is null)
            throw new ArgumentException("No fields was found at given file.");

        var newFields = CreateNewFields();

        foreach (var field in ContractFieldModel.Fields)
        {
            if (templateFields.ContainsKey(field.Value) 
                && newFields.TryGetValue(field.Value, out var newField))
                templateFields[field.Value] = newField;
        }
        
        return templateFields;
    }

    private Dictionary<string, string> CreateNewFields() => new()
        {
            { ContractFieldModel.ContractDate, ContractDate.ToString(CultureInfo.InvariantCulture) },
            { ContractFieldModel.LandlordFullname, Landlord.Name},
            { ContractFieldModel.LandlordPhoneNumber, Landlord.PhoneNumber},
            { ContractFieldModel.LandlordEmail, Landlord.Email},
            { ContractFieldModel.LandlordContactAddress, Landlord.ContactAddress!},
            { ContractFieldModel.TenantFullname, Tenant.Name},
            { ContractFieldModel.TenantPhoneNumber, Tenant.PhoneNumber},
            { ContractFieldModel.TenantEmail, Tenant.Email is null or "" ? "нет" : Tenant.Email},
            { ContractFieldModel.PropertyAddress, Entity.Property.Address},
            { ContractFieldModel.LeaseStartDateTime, Entity.EntryDate.ToString(CultureInfo.InvariantCulture)},
            { ContractFieldModel.LeaseEndDateTime, (Entity.EntryDate + Entity.Duration).ToString(CultureInfo.InvariantCulture)},
            { ContractFieldModel.PaymentAmount, PaymentAmount.ToString(CultureInfo.InvariantCulture)},
            { ContractFieldModel.PaymentFrequency, PaymentFrequency}
        };
}