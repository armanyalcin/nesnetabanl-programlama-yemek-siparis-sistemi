using FoodOrderingSystem.Models;

var c = new Customer(
    2,
    "Alihan",
    "alihan@example.com",
    "Istanbul",
    "0555 000 00 00"
);

Console.WriteLine($"{c.Name} - {c.Address} - {c.Phone}");
