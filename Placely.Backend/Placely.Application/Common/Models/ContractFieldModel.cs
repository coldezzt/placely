using System.Reflection;

namespace Placely.Application.Common.Models;

public class ContractFieldModel
{
    public static readonly Dictionary<string, string> Fields;

    static ContractFieldModel()
    {
        Fields = typeof(ContractFieldModel)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi is {IsLiteral: true, IsInitOnly: false})
            .ToDictionary(fi => fi.Name, fi => (string) fi.GetRawConstantValue()!);
    }

    public const string ContractDate = "ContractDate";
    public const string LandlordFullname = "LandlordFullname";
    public const string LandlordPhoneNumber = "LandlordPhoneNumber";
    public const string LandlordEmail = "LandlordEmail";
    public const string LandlordContactAddress = "LandlordContactAddress";
    public const string TenantFullname = "TenantFullname";
    public const string TenantPhoneNumber = "TenantPhoneNumber";
    public const string TenantEmail = "TenantEmail";
    public const string PropertyAddress = "PropertyAddress";
    public const string LeaseStartDateTime = "LeaseStartDateTime";
    public const string LeaseEndDateTime = "LeaseEndDateTime";
    public const string PaymentAmount = "PaymentAmount";
    public const string PaymentFrequency = "PaymentFrequency";
}