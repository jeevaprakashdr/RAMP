using API.Db;

namespace API.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly ApiDatabaseContext _databaseContext;

    public OrderRepository(ApiDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public bool Add(Order order)
    {
        _databaseContext.Add(order);
        return  _databaseContext.SaveChanges() > 0;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _databaseContext.Orders.ToList();
    }
    
    public WalletAggregateDto GetWalletWithMaxOrders()
    {
        return _databaseContext.Orders
            .GroupBy(order => order.WalletAddress)
            .Select(orders => new WalletAggregateDto
            {
                WalletAddress = orders.Key,
                TransactionCount = orders.Count(),
                Unit = orders.Sum(order => order.Unit)
            })
            .OrderByDescending(arg => arg.Unit)
            .First();
    }
}