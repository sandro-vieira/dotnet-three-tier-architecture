namespace DevIO.Business.Models;

public class Address : Entity
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string AdditionalInfo { get; set; } = string.Empty;
    public string PostalCode {  get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Entity Framework relationship
    /// </summary>
    public Supplier Supplier { get; set; } = new();
}