using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Services;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Presentation.UI
{
    public class ConsoleMenu
    {
        private OfficeService _officeService;
        private OrderService _orderService;

        public ConsoleMenu(OfficeService officeService, OrderService orderService)
        {
            _officeService = officeService;
            _orderService = orderService;
        }

        public void ShowMainMenu() 
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("===== Bakery Fresh Bread =====");
                Console.WriteLine("Select a bakery office: ");

                var offices = _officeService.GetAllOffices();
                var count = 1;
                foreach (var office in offices) 
                {
                    Console.WriteLine($"{count++}. {office.Name} - Address: {office.Address}");
                }
                Console.WriteLine("0. Exit");

                Console.Write("Choose One: ");
                var input = Console.ReadLine();

                try
                {
                    int selected = int.Parse(input);
                    if (selected < 0 || selected > offices.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (selected == 0)
                    {
                        Console.WriteLine("Exit Menu. Have a nice day.");
                        break;
                    }

                    // Handle the selected office here

                    var office = offices[selected-1];
                    ShowOfficeMenu(office);

                }
                catch (FormatException)
                {
                    DisplayErrorMessage("Invalid input. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    DisplayErrorMessage("Invalid input. Please enter a number corresponding to the options listed.");
                }
            }
        }

        private void ShowOfficeMenu(BakeryOffice office) 
        {
            while (true) {
                Console.Clear();
                Console.WriteLine($"===== {office.Name} =====");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Process All Orders");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("Choose One: ");
                var input = Console.ReadLine();

                switch (input) 
                {
                    case "1":
                        ShowAddOrderMenu(office);
                        break;
                    case "2":
                        ShowPreparationOrders(office);
                        Console.ReadKey();
                        break;
                    case "0": return;
                    default:
                        DisplayErrorMessage("Invalid option...");
                        break;
                }
            }
        }

        private void ShowAddOrderMenu(BakeryOffice office) 
        { 
            var order = new OrderList("customer name");
            var breads = office.Menu;

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("===== Creating new order =====");
                Console.WriteLine("Enter bread type: ");
                for (int i = 0; i < breads.Count; i++) {
                    var bread = breads[i];
                    Console.WriteLine($"{i + 1}. {bread.Name}");
                }
                Console.WriteLine("0. Finish Order");

                

                Console.WriteLine("Current Order made: ");
                Console.WriteLine("------ ------");
                foreach (var detail in order.Details) 
                {
                    Console.WriteLine(detail.ToString());
                }
                Console.WriteLine("------ ------");

                Console.Write("Choose One: ");
                var select = int.Parse(Console.ReadLine()); // Control error

                if (select == 0) 
                {
                    // Control amount limit and confirmation message
                    office.AddOrder(order);
                    return;
                }

                Console.Write("Enter the Quantity: ");
                var quantity = int.Parse(Console.ReadLine());

                order.AddOrder(breads[select - 1], quantity);

            }
        }

        private void ShowPreparationOrders(BakeryOffice office) 
        { 
            _orderService.ProcessOrders(office.Name);
        }


        private void DisplayErrorMessage(string message) 
        {
            Console.WriteLine($"Error: {message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
