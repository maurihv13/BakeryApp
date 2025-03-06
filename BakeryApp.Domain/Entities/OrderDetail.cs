
namespace BakeryApp.Domain.Entities
{
    public class OrderDetail
    {
        public Bread Bread { get; }
        public int Amount { get; set; }

        public OrderDetail(Bread bread) 
        {
            this.Bread = bread;
        }
        public OrderDetail(Bread bread, int amount) 
        {
            this.Bread = bread;
            this.Amount = amount;
        }
        public double GetPrice() 
        {
            return Bread.Price * Amount;
        }

        public override string ToString() {
            return $"Bread: {Bread.Name} - Amount: {Amount}";
        }
    }
}
