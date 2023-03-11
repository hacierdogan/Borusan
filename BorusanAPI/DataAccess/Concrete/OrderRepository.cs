using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public async Task<Order> GetOrderByOrderNo(string orderNo)
        {
            using (var db = new DataContext())
            {
                return await db.Orders.FirstOrDefaultAsync(w => w.OrderNo.ToUpper() == orderNo.ToUpper());
            }
        }
    }
}
