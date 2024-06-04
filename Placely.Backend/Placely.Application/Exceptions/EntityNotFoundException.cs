using System.Reflection;

namespace Placely.Application.Exceptions;

public class EntityNotFoundException(MemberInfo entity, string? key) 
    : Exception($"Сущность {entity.Name} по ключу {key} не была найдена");