using Placely.Data.Abstractions;

namespace Placely.Data.Entities;

public class PropertyOption : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public List<Property> Properties { get; set; }
}