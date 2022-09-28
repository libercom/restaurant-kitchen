using Kitchen.Dtos;
using Kitchen.Models;

namespace Kitchen.Services
{
    public interface IKitchenService
    {
        public Task DistributeOrder(Order order);
        public void TakeOrder(OrderDto orderDto);
    }
}
