namespace CrudLatest.Shared.Models;

public class Item
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
