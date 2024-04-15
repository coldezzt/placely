using System.Reflection;
using FluentValidation.Results;

namespace Placely.Main.Exceptions;

public class EntityValidationFailedException(MemberInfo entity, IEnumerable<ValidationFailure> results) 
    : Exception($"{entity.Name} is invalid. Info: {string.Join("; ", results.Select(result => result.ErrorMessage))}");
