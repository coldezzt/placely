namespace Placely.Application.Exceptions;

public class ConflictException(string? info = null) 
    : Exception("Значение не было добавлено из-за конфликта." + (info is null 
            ? "" 
            : $"Дополнительно: {info}")
        );