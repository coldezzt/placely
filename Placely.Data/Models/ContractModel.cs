using System.Globalization;
using System.Text.Json;
using Placely.Data.Entities;

namespace Placely.Data.Models;

public class ContractModel(
    Contract contractEntity, 
    decimal paymentAmount, 
    string paymentFrequency)
{
    public DateTime ContractDate { get; } = DateTime.Now;
    public Contract Contract { get; } = contractEntity;
    public decimal PaymentAmount { get; } = paymentAmount;
    public string PaymentFrequency { get; } = paymentFrequency;

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
            { ContractField.LandlordFullname, Contract.Landlord.Tenant.Name},
            { ContractField.LandlordPhoneNumber, Contract.Landlord.Tenant.PhoneNumber},
            { ContractField.LandlordEmail, Contract.Landlord.Tenant.Email},
            { ContractField.LandlordContactAddress, Contract.Landlord.ContactAddress},
            { ContractField.TenantFullname, Contract.Tenant.Name},
            { ContractField.TenantPhoneNumber, Contract.Tenant.PhoneNumber},
            { ContractField.TenantEmail, Contract.Tenant.Email},
            { ContractField.PropertyAddress, Contract.Property.Address},
            { ContractField.LeaseStartDateTime, Contract.LeaseStartDate.ToString(CultureInfo.InvariantCulture)},
            { ContractField.LeaseEndDateTime, Contract.LeaseEndDate.ToString(CultureInfo.InvariantCulture)},
            { ContractField.PaymentAmount, PaymentAmount.ToString(CultureInfo.InvariantCulture)},
            { ContractField.PaymentFrequency, PaymentFrequency}
        };
}