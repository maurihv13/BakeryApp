
namespace BakeryApp.Domain.Entities

{
    public class BakeryOffice
    {
        public string Name { get; }
        public string Address { get; }
        private readonly int _maxCapacity;
        private int _currentAmount;
        public List<Bread> Menu { get; }
        public List<OrderList> Orders { get; }

        public BakeryOffice(string name, string address, int maxCapacity) 
        {
            Name = name;
            Address = address;
            _maxCapacity = maxCapacity;
            Menu = [];
            Orders = [];
        }

        public void AddBread(Bread bread) 
        {
            Menu.Add(bread);
        }

        public bool AddOrder(OrderList newOrder)
        {
            int orderAmount = newOrder.OrderAmount();
            if (!CanAcceptOrder(orderAmount)) return false;
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
