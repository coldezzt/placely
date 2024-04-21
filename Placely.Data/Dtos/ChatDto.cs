namespace Placely.Data.Dtos;

public class ChatDto
{
    public long Id { get; set; }
    public long FirstUserId { get; set; }
    public long SecondUserId { get; set; }
    public string DirectoryPath { get; set; }
}