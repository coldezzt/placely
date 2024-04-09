namespace Placely.Data.Entities;

public class PropertyOption
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public List<Property> Properties { get; set; }
}