using API.Dto;

namespace API.Controllers;

public sealed class OrderFulfillmentResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Wallet Data { get; set; }
}