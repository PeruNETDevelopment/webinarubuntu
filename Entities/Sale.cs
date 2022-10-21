namespace WebinarUbuntu.Entities;

public class Sale : EntityBase
{
    public DateTime SaleDate { get; set; }
    public string SaleNumber { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
    public int CustomerId { get; set; }
    public decimal TotalSale { get; set; }
}