namespace Placely.Main.Exceptions;

public class ContractServiceException(IEnumerable<string> errors) 
    : Exception($"Произошла ошибка во время создания контракта. Информация: {string.Join(" || ", errors)}");