using System.Reflection;

namespace Placely.Data.Exceptions;

public class EntityNotFoundException(MemberInfo entity, string? key) 
    : Exception($"{entity.Name} with key {key} was not found");