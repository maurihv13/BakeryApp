// See https://aka.ms/new-console-template for more information

using BakeryApp.Application.Interfaces;
using BakeryApp.Application.Services;
using BakeryApp.Infrastructure;
using BakeryApp.Presentation.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var officeService = host.Services.GetRequiredService<IOfficeService>();
        var orderService = host.Services.GetRequiredService<IOrderService>();

        var menu = new ConsoleMenu(officeService, orderService);
        await menu.ShowMainMenuAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddInfrastructure(context.Configuration);
                services.AddScoped<IOfficeService, OfficeService>();
                services.AddScoped<IOrderService, OrderService>();
            });
}