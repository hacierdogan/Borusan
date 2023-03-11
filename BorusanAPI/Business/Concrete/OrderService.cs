using Business.Abstract;
using DataAccess.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderService : IOrderService
    {
        protected IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrderByOrderNo(string orderNo)
        {
            return await _orderRepository.GetOrderByOrderNo(orderNo);
        }

        public async Task<Order> TCreate(Order order)
        {
            return await _orderRepository.Create(order);
        }

        public async Task TDelete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<List<Order>> TGetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> TGetById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<Order> TUpdate(Order order)
        {
            return await _orderRepository.Update(order);
        }
    }
}
