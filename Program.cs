using FoodOrderingSystem.Models;

var r = new Restaurant(1, "Burger Kral");
r.AddMenuItem(new MenuItem(1, "Cheeseburger", 180, "Burger"));
r.AddMenuItem(new MenuItem(2, "Patates Kızartması", 70, "Yan Ürün"));
r.AddMenuItem(new MenuItem(3, "Kola", 40, "İçecek"));

var customer = new Customer(1, "Alihan", "alihan@example.com", "Istanbul", "0555 000 00 00");

var order = new Order(1001, customer, r);

// sepete ekleme (şimdilik direkt nesne ile)
order.AddItem(r.Menu[0]);
order.AddItem(r.Menu[2]);

order.PrintSummary();

// bir ürün çıkarma testi
order.RemoveItem(3);
order.PrintSummary();
