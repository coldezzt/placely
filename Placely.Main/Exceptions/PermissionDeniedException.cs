namespace Placely.Main.Exceptions;

public abstract class PermissionDeniedException(string source) 
    : Exception($"Access denied for {source}");