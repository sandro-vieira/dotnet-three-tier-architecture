namespace DevIO.Business.Models;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; }

    /// <summary>
    /// Entity Framework relationship
    /// </summary>
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = new();
}
