using API.Clients;
using API.Db;
using API.Dto;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : Controller
{
    private readonly IOrderRepository _repository;
    private readonly ITestNetClient _testNetClient;

    public OrderController(IOrderRepository repository, ITestNetClient testNetClient)
    {
        _repository = repository;
        _testNetClient = testNetClient;
    }
    
    /// <summary>
    /// Send asset to the wallet
    /// </summary>
    /// <param name="request">the request</param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public IActionResult Fulfillment([FromBody] OrderFulfillmentRequest request)
    {
        var response = _testNetClient.SendAsset(request);
        
        var order = new Order
        {
            WalletAddress = request.walletAddress,
            Unit = request.CryptoUnitCount,
            Status = response.Success,
            Created = DateTime.Now,
        };
        
        _repository.Add(order);
        
        return response.Success 
            ? Ok() 
            : StatusCode(StatusCodes.Status500InternalServerError, "failed to send asset to wallet");
    }
    
    /// <summary>
    /// Gets Wallet Details with maximum number of orders
    /// </summary>
    /// <returns>Wallet Details</returns>
    [ProducesResponseType(typeof(WalletAggregateDto), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult Analytics()
    {
        var walletResponse = _repository.GetWalletWithMaxOrders();
        return Ok(walletResponse);
    }
    
    /// <summary>
    /// Get all order
    /// </summary>
    /// <returns>Orders</returns>
    [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetOrder()
    {
        var order = _repository.GetOrders()
            .Select(order => new OrderResponse
            {
                WallertAddress = order.WalletAddress,
                Units = order.Unit,
                Created = order.Created,
                Status = order.Status,
            });
        return Ok(order);
    }
}