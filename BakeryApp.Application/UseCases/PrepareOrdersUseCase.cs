using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Services;

namespace BakeryApp.Application.UseCases
{
    public class PrepareOrdersUseCase
    {
        private readonly OrderService _orderService;

        public PrepareOrdersUseCase(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void Execute(string officeName) 
        {
            // Interaction
        }
    }
}
