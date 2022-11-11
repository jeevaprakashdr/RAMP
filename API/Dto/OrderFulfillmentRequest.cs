namespace API.Dto;

public sealed class OrderFulfillmentRequest
{
    public int CryptoUnitCount { get; set; }
    
    public string cryptoCurrencyName { get; set; }
    
    public string walletAddress { get; set; }
}