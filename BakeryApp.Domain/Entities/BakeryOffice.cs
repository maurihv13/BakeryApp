using System.Collections.Generic;

namespace BakeryApp.Domain.Entities

{
    public class BakeryOffice
    {
        private readonly string _name;
        private readonly string _address;
        private readonly int _maxCapacity;
        private int _currentAmount;
        private List<Bread> _menu;
        public List<OrderList> Orders { get; }

        public BakeryOffice(string name, string address, int maxCapacity) 
        {
            _name = name;
            _address = address;
            _maxCapacity = maxCapacity;
            _menu = [];
            Orders = [];
        }

        public void AddBread(Bread bread) 
        {
            _menu.Add(bread);
        }

        public bool AddOrder(OrderList newOrder)
        {
            int orderAmount = newOrder.OrderAmount();
            if (CanAcceptOrder(orderAmount)) return false;
            Orders.Add(newOrder);
            _currentAmount += orderAmount;
            return true;
        }

        private bool CanAcceptOrder(int orderAmount) {
            return RemainingCapacity() >= orderAmount;
        }

        public int RemainingCapacity() { 
            return _maxCapacity - _currentAmount; 
        }

        public void CleanOrders() {
            Orders.Clear();
            _currentAmount = 0;
        }
    }
}
