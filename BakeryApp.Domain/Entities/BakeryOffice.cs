
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

        private List<OrderList> _prepared;

        public BakeryOffice(string name, string address, int maxCapacity) 
        {
            Name = name;
            Address = address;
            _maxCapacity = maxCapacity;
            Menu = [];
            Orders = [];
            _prepared = [];
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
            SavePrepared();
            Orders.Clear();
            _currentAmount = 0;
        }

        public double GetTotalEarned() 
        {
            double totalEarned = 0;
            foreach (var order in _prepared) 
            {
                totalEarned += order.TotalPrice();
            }
            return totalEarned;
        }

        public int GetNumberPrepared() 
        {
            return _prepared.Count;
        }

        private void SavePrepared() 
        {
            foreach (var order in Orders)
            {
                var copiedOrder = new OrderList(order.CustomerName);
                foreach (var detail in order.Details)
                {
                    copiedOrder.AddOrder(new OrderDetail(detail.Bread, detail.Amount));
                }
                _prepared.Add(copiedOrder);
            }
        }
    }
}
