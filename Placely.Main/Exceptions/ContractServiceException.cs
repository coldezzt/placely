namespace Placely.Main.Exceptions;

public class ContractServiceException(IEnumerable<string> errors) 
    : Exception($"An error was occured while creating an contract. Info: {string.Join(" || ", errors)}");