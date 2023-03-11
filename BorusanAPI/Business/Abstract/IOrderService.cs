using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<Order> GetOrderByOrderNo(string orderNo);
    }
}
