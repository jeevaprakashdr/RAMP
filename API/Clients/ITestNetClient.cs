using API.Controllers;
using API.Dto;

namespace API.Clients;

public interface ITestNetClient
{
    OrderFulfillmentResponse SendAsset(OrderFulfillmentRequest request);
}