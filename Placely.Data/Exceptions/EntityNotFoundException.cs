using System.Reflection;

namespace Placely.Data.Exceptions;

public class EntityNotFoundException(MemberInfo entity, string? key) 
    : Exception($"Сущность {entity.Name} по ключу {key} не была найдена");