// See https://aka.ms/new-console-template for more information
using BakeryApp.Infrastructure.Repositories;

Console.WriteLine("Hello, World!");

var repository = new FakeBakeryOfficeRepository();
var bakerryOffices = repository.GetAllBakeryOffices();

foreach (var office in bakerryOffices) 
{
    Console.WriteLine(office.Name);
}

