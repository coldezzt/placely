namespace Placely.Domain.Common.Enums;

/// <summary>
/// Класс, определяющий возможные роли пользователей.
/// </summary>
public static class UserRoleType
{
    /// <summary>
    /// Роль для арендатора.
    /// </summary>
    public const string Tenant = "Tenant";
    
    /// <summary>
    /// Роль для арендодателя.
    /// </summary>
    public const string Landlord = "Landlord";

    /// <summary>
    /// Роль для модератора.
    /// </summary>
    public const string Moderator = "Moderator"; 
    
    /// <summary>
    /// Роль для админа.
    /// </summary>
    public const string Admin = "Admin";
}