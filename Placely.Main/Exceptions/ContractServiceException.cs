namespace Placely.Main.Exceptions;

public class ContractServiceException(string? error) 
    : Exception("Произошла ошибка во время взаимодействия с контрактом. " + (error is null 
            ? "" 
            : "Дополнительно: " + error)
        );