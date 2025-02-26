namespace BakeryApp.Domain.Entities

{
    public class BakeryOffice
    {
        public string Name;
        public string Address;
        public int maxCapacity;
        public List<Bread> Menu;
        public List<OrderList> Orders;
    }
}
