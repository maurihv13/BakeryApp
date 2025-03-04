using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Services;
using BakeryApp.Application.UseCases;
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
            var breadItems = new List<(string BreadType, int Quantity)>();
            var breads = _officeService.GetBreads(office.Name);
            var addOrder = new AddOrderUseCase(_orderService);

            Console.Write("Introduce customer's name: ");

            string? customerName = Console.ReadLine();
            if (string.IsNullOrEmpty(customerName))
            {
                DisplayErrorMessage("Customer name cannot be empty.");
                return;
            }

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("===== Creating new order =====");
                Console.WriteLine("Enter bread type: ");
                for (int i = 0; i < breads.Count; i++) {
                    var bread = breads[i];
                    Console.WriteLine($"{i + 1}. {bread}");
                }
                Console.WriteLine("0. Finish Order");

                

                Console.WriteLine($"Current {customerName}'s order:");
                if (breadItems.Count > 0) 
                { 
                    Console.WriteLine("====== * ======");
                    foreach (var item in breadItems) 
                    {
                        Console.WriteLine($"{item.BreadType} - {item.Quantity}");
                    }
                    Console.WriteLine("====== * ======");
                }

                Console.Write("Choose One: ");
                var input = Console.ReadLine(); // Control error

                try
                {
                    var select = int.Parse(input);
                    if (select == 0)
                    {
                        double orderPrice = addOrder.GetPrice(breadItems);
                        Console.WriteLine($"Total order price: {orderPrice}");
                        Console.Write("Are you sure you want to finish the order? (yes/no): ");
                        var confirmation = Console.ReadLine();
                        if (confirmation?.ToLower() == "yes")
                        {
                            var result = addOrder.Execute(office.Name, breadItems, customerName);
                            DisplayMessage(result);
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Console.Write("Enter the Quantity: ");
                    input = Console.ReadLine();
                    var quantity = int.Parse(input);

                    breadItems.Add((breads[select - 1], quantity));
                }
                catch (FormatException)
                {
                    DisplayErrorMessage("Invalid input. Please enter a valid number.");
                }
                catch (Exception ex) 
                {
                    DisplayErrorMessage(ex.Message);
                }
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

        private void DisplayMessage(string message) 
        {
            Console.WriteLine($"{message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
