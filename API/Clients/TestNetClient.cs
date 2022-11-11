using API.Controllers;
using API.Dto;

namespace API.Clients;

public sealed class TestNetClient : ITestNetClient
{
    public OrderFulfillmentResponse SendAsset(OrderFulfillmentRequest request)
    {
        var random = new Random();
        var success = random.Next(5) > 0;
        var messageTemplate = $"Wallet transfer to walletId {request.walletAddress}";
        var message = success ? $"{messageTemplate} is success" : $"{messageTemplate} is failed";
        return new OrderFulfillmentResponse
        {
            Message = message,
            Success = success,
            Data = new Wallet
            {
                Address = request.walletAddress
            }
        };
    }
}