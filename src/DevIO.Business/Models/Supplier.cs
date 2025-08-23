namespace DevIO.Business.Models;

public class Supplier : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public SupplierType SupplierType { get; set; } = SupplierType.Undefined;
    public Address Address { get; set; } = new();
    public bool IsActive { get; set; }

    /// <summary>
    /// Entity Framework relationship
    /// </summary>
    public ICollection<Product> Products { get; set; } = [];
}
