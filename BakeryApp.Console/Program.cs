// See https://aka.ms/new-console-template for more information

using BakeryApp.Application.Services;
using BakeryApp.Infrastructure.Repositories;
using BakeryApp.Presentation.UI;

class Program
{
    static void Main(string[] args) 
    {
        var officeRepository = new FakeBakeryOfficeRepository();
        var officeService = new OfficeService(officeRepository);
        var orderService = new OrderService(officeService);

        var menu = new ConsoleMenu(officeService, orderService);
        menu.ShowMainMenu();
    }
}
