using System;
using System.Linq;
using System.Collections.Generic;
using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public abstract class CustomerBase : ICustomer
    {
        private readonly OrderRepository _orderRepository;
        private readonly ReturnRepository _returnRepository;

        protected CustomerBase(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            _orderRepository = orderRepo;
            _returnRepository = returnRepo;
        }

        public abstract string GetName();
        
        public void CreateOrder(IOrder order)
        {
            _orderRepository.Add(order);
        }

        public List<IOrder> GetOrders()
        {
            return _orderRepository.Get();
        }

        public void CreateReturn(IReturn rga)
        {
            _returnRepository.Add(rga);
        }

        public List<IReturn> GetReturns()
        {
            return _returnRepository.Get();
        }

        public float GetTotalSales()
        {
            var totalOrders = GetOrders().Where(x=>x.Customer.GetName() == this.GetName());
            float totalPrice = 0;
            foreach (var order in totalOrders)
            {
                var orderProducts = order.Products;
                foreach (var product in orderProducts)
                {
                    totalPrice = totalPrice + product.Product.GetSellingPrice();
                }
            }

            return totalPrice;
        }

        public float GetTotalReturns()
        {
            var returnsList = this.GetReturns().Where(x => x.OriginalOrder.Customer.GetName() == this.GetName()); 
            float totalReturnPrice = 0;
            foreach(var returnItem in returnsList)
            {
                var returnProducts = returnItem.ReturnedProducts;
                foreach (var product in returnProducts)
                {
                    totalReturnPrice = totalReturnPrice + product.OrderProduct.Product.GetSellingPrice();
                }
            }
            return totalReturnPrice;            
        }

        public float GetTotalProfit()
        {
            return this.GetTotalSales() - this.GetTotalReturns();
        }
    }
}
