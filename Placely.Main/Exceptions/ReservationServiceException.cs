namespace Placely.Main.Exceptions;

public class ReservationServiceException(string? info) 
    : Exception("Ошибка взаимодействия с резервированием. " + (info is null 
            ? "" 
            : "Дополнительно: " + info)
        );