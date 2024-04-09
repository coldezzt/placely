using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Placely.Main.Exceptions;

public abstract class EntityValidationFailedException(MemberInfo entity, IEnumerable<ValidationResult> results) 
    : Exception($"{entity.Name} is invalid. Info: {string.Join("; ", results.Select(result => result.ErrorMessage))}");
