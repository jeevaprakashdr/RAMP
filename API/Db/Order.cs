namespace API.Db;

public sealed class Order
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public decimal Unit { get; set; }
    public string WalletAddress { get; set; }
    public bool Status { get; set; }
}