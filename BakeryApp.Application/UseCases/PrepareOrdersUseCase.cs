
using System.Text;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.UseCases
{
    public class PrepareOrdersUseCase
    {
        private readonly IOrderService _orderService;

        public PrepareOrdersUseCase(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public string Execute(string officeName)
        {
            var orders = _orderService.GetOrders(officeName);

            if (orders.Count == 0) return "No orders to process.";

            var baguetteDetail = new OrderDetail(new Baguette());
            var whiteBreadDetail = new OrderDetail(new WhiteBread());
            var milkBreadDetail = new OrderDetail(new MilkBread());
            var hamburguerBunDetail = new OrderDetail(new HamburguerBun());
            foreach (var order in orders)
            {
                foreach (var detail in order.Details) 
                {
                    switch (detail.Bread)
                    {
                        case Baguette _:
                            baguetteDetail.Amount += detail.Amount;
                            break;
                        case WhiteBread _:
                            whiteBreadDetail.Amount += detail.Amount;
                            break;
                        case MilkBread _:
                            milkBreadDetail.Amount += detail.Amount;
                            break;
                        case HamburguerBun _:
                            hamburguerBunDetail.Amount += detail.Amount;
                            break;
                        default:
                            break;
                    }
                }
            }
            var sb = new StringBuilder();
            var details = new List<OrderDetail> { baguetteDetail, whiteBreadDetail, milkBreadDetail, hamburguerBunDetail };
            foreach (var detail in details) 
            { 
                var bread = detail.Bread;
                var preparation = bread.MakeBread(detail.Amount);
                if (!preparation.Equals("")) sb.AppendLine(preparation);
            }
            _orderService.ProcessOrders(officeName);
            sb.AppendLine("All orders were prepared!");
            return sb.ToString();
        }
    }
}
