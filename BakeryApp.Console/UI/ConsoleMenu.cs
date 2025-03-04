using BakeryApp.Application.Interfaces;
using BakeryApp.Application.UseCases;

namespace BakeryApp.Presentation.UI
{
    public class ConsoleMenu
    {
        private IOfficeService _officeService;
        private IOrderService _orderService;

        public ConsoleMenu(IOfficeService officeService, IOrderService orderService)
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

                var officesNames = _officeService.GetOfficesNames();
                var count = 1;
                foreach (var office in officesNames) 
                {
                    Console.WriteLine($"{count++}. {office}");
                }
                Console.WriteLine("0. Exit");

                Console.Write("Write your selection: ");
                var input = Console.ReadLine();

                try
                {
                    int selected = int.Parse(input);
                    if (selected < 0 || selected > officesNames.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (selected == 0)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("Exit Program, Have a nice day.");
                        break;
                    }

                    var office = officesNames[selected-1];
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

        private void ShowOfficeMenu(string office) 
        {
            while (true) {
                var officeData = _officeService.GetOfficeData(office);
                Console.Clear();
                Console.WriteLine($"===== {office} =====");
                Console.WriteLine($"Address: {officeData.Address}");
                Console.WriteLine($"Remaining capacity: {officeData.RemainingCapacity}");
                Console.WriteLine($"Current orders: {officeData.OrderCount}");
                Console.WriteLine($"===== Options =====");

                Console.WriteLine("1. Add Order");
                if (officeData.OrderCount > 0) Console.WriteLine("2. Process All Orders");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("Write your selection: ");
                var input = Console.ReadLine();

                switch (input) 
                {
                    case "1":
                        ShowAddOrderMenu(office);
                        break;
                    case "2":
                        ShowPreparationOrders(office);
                        break;
                    case "0": return;
                    default:
                        DisplayErrorMessage("Invalid option...");
                        break;
                }
            }
        }

        private void ShowAddOrderMenu(string office) 
        {
            var breadItems = new List<(string BreadType, int Quantity)>();
            var breads = _officeService.GetBreads(office);
            var addOrder = new AddOrderUseCase(_orderService, _officeService);

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
                Console.WriteLine("Select an order option: ");
                for (int i = 0; i < breads.Count; i++) {
                    var bread = breads[i];
                    Console.WriteLine($"{i + 1}. Order {bread}");
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
                else { Console.WriteLine(" ** Still with no orders made ** "); }

                Console.Write("Write your selection: ");
                var input = Console.ReadLine();

                try
                {
                    var select = int.Parse(input);

                    if (select < 0 || select > breads.Count) 
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (select == 0)
                    {
                        if (breadItems.Count == 0) return;
                        var finished = ShowFinishOrder(office, breadItems, customerName);
                        if (finished) { return; }
                        else { continue; }
                    }

                    Console.Write("Enter the Quantity: ");
                    input = Console.ReadLine();
                    var quantity = int.Parse(input);

                    if (quantity <= 0) {
                        DisplayErrorMessage("Invalid quantity entered. Try again");
                        continue;

                    }

                    breadItems.Add((breads[select - 1], quantity));
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

        private void ShowPreparationOrders(string office) 
        {
            PrepareOrdersUseCase prepare = new PrepareOrdersUseCase(_orderService);
            string result = prepare.Execute(office);
            DisplayMessage(result);
        }

        private bool ShowFinishOrder(string office, List<(string BreadType, int Quantity)> breadItems, string customerName) 
        {
            bool finished = false;
            var addOrder = new AddOrderUseCase(_orderService, _officeService);
            double orderPrice = addOrder.GetPrice(breadItems);
            Console.WriteLine($"Total order price: {orderPrice}");
            Console.Write("Are you sure you want to finish the order? (yes/no): ");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "yes")
            {
                var result = addOrder.Execute(office, breadItems, customerName);
                DisplayMessage(result);
                finished = true;
            }
            return finished;
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
