namespace API.Repositories;

public sealed class WalletAggregateDto
{
    public string WalletAddress { get; set; }
    public int TransactionCount { get; set; }
    public decimal Unit { get; set; }
}