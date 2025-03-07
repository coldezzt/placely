namespace Placely.Application.Common.Exceptions;

public class AddressException(string? info) 
    : Exception("Проблема с адресом. " + (info is null 
            ? "" 
            : "Дополнительно: " + info)
        );