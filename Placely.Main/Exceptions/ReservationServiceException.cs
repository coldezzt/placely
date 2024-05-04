namespace Placely.Main.Exceptions;

public class ReservationServiceException(string? info) 
    : Exception("Резервирование не было добавлено. " + (info is null 
            ? "" 
            : "Дополнительно: " + info)
        );