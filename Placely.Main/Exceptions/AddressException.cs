namespace Placely.Main.Exceptions;

public class AddressException(string? info) 
    : Exception("Проблема с адресом. " + (info is null 
            ? "" 
            : "Дополнительно: " + info)
        );