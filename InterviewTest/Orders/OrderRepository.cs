using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Orders
{
    public class OrderRepository
    {
        private List<IOrder> orders;
        public OrderRepository()
        {
            orders = new List<IOrder>();
        }

        public void Add(IOrder newOrder)
        {
            orders.Add(newOrder);
        }

        public void Remove(IOrder removedOrder)
        {
            orders = orders.Where(o => !string.Equals(removedOrder.OrderNumber, o.OrderNumber)).ToList();
        }

        public List<IOrder> Get()
        {
            return orders;
      
        }

        /*
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //-------------saving order------------

        public async Task SaveOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        //----------updating order------------
        public async Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //-----------pulling order--------------
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)    //customer
                .Include(o => o.Products)    //products
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
         */



    }


}
