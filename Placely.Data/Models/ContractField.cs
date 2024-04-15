using System.Reflection;

namespace Placely.Data.Models;

public class ContractField
{
    public static readonly Dictionary<string, string> Fields;

    static ContractField()
    {
        Fields = typeof(ContractField)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi is {IsLiteral: true, IsInitOnly: false})
            .ToDictionary(fi => fi.Name, fi => (string) fi.GetRawConstantValue()!);
    }

    public const string ContractDate = "CONTRACT-DATE";
    public const string LandlordFullname = "LANDLORD-FULLNAME";
    public const string LandlordPhoneNumber = "LANDLORD-PHONE-NUMBER";
    public const string LandlordEmail = "LANDLORD-EMAIL";
    public const string LandlordContactAddress = "LANDLORD-CONTACT-ADDRESS";
    public const string TenantFullname = "TENANT-FULLNAME";
    public const string TenantPhoneNumber = "TENANT-PHONE-NUMBER";
    public const string TenantEmail = "TENANT-EMAIL";
    public const string PropertyAddress = "PROPERTY-ADDRESS";
    public const string LeaseStartDateTime = "LEASE-START-DATE-TIME";
    public const string LeaseEndDateTime = "LEASE-END-DATE-TIME";
    public const string PaymentAmount = "PAYMENT-AMOUNT";
    public const string PaymentFrequency = "PAYMENT-FREQUENCY";
}