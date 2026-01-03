using FoodOrderingSystem.Models;

var r = new Restaurant(1, "Burger Kral");

r.AddMenuItem(new MenuItem(1, "Cheeseburger", 180, "Burger"));
r.AddMenuItem(new MenuItem(2, "Patates Kızartması", 70, "Yan Ürün"));
r.AddMenuItem(new MenuItem(3, "Kola", 40, "İçecek"));

r.ShowMenu();

// opsiyonel rating testi
r.AddRating(5);
r.AddRating(4);
Console.WriteLine($"\nRating: {r.Rating:0.0} ({r.RatingCount} oy)");
