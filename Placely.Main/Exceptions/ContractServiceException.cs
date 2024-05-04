namespace Placely.Main.Exceptions;

public class ContractServiceException(string? error) 
    : Exception("Произошла ошибка во время создания контракта. " + (error is null 
            ? "" 
            : "Дополнительно: " + error)
        );