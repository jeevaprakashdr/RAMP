using API.Db;

namespace API.Repositories;

public interface IOrderRepository
{
    bool Add(Order order);
    IEnumerable<Order> GetOrders();
    WalletAggregateDto GetWalletWithMaxOrders();
}