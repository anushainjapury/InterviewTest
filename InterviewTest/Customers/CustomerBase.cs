using System;
using System.Linq;
using System.Collections.Generic;
using InterviewTest.Orders;
using InterviewTest.Returns;
using InterviewTest.Models;

namespace InterviewTest.Customers
{
    public abstract class CustomerBase : ICustomer
    {
        private readonly OrderRepository _orderRepository;
        private readonly ReturnRepository _returnRepository;
        private int _totalOrderedItems;
        public int TotalOrderedItems => _totalOrderedItems;

        private List<IOrder> _orders = new List<IOrder>();
        private List<IReturn> _returns = new List<IReturn>();
        public void IncrementTotalOrderedItems(int count)
        {
            _totalOrderedItems += count;
        }


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
            var totalOrders = GetOrders().Where(x=>x.Customer.GetName() == this.GetName()); //retrieves the orders that are associated with a particular customer
            float totalPrice = 0; //intializing totalPrice
            foreach (var order in totalOrders) //loops through each order  for the specific customer
            {
                var orderProducts = order.Products; //retrieves the products that are contained in the order
                foreach (var product in orderProducts) //loops through the products in each order to get total selling price for the order
                {
                    totalPrice = totalPrice + product.Product.GetSellingPrice(); //calculates the total selling price for the products in the order for this particular customer
                }
            }

            return totalPrice; //returns the total price which is the total sales for this particular customer
        }

        public float GetTotalReturns()
        {
            var returnsList = this.GetReturns().Where(x => x.OriginalOrder.Customer.GetName() == this.GetName()); //retrieves returns that are associated with a particular customer 
            float totalReturnPrice = 0; //initializing the total return in price 
            foreach(var returnItem in returnsList) //loops through each return associated with a particular customer
            {
                var returnProducts = returnItem.ReturnedProducts; //retrieves returned products associated with this return item
                foreach (var product in returnProducts) //loops through each returned product to get total return price
                {
                    totalReturnPrice = totalReturnPrice + product.OrderProduct.Product.GetSellingPrice(); //calculates total return price 
                }
            }
            return totalReturnPrice; //returns the total return price 
        }

        public float GetTotalProfit()
        {
            return this.GetTotalSales() - this.GetTotalReturns(); //assuming that profit is calculated by (total sales) - (total returns) given that there's no purchasing price for each product. 
        }


    }
}
