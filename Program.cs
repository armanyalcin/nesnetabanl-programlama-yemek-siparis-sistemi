using FoodOrderingSystem.Models;

var r = new Restaurant(1, "Burger Kral");
r.AddMenuItem(new MenuItem(1, "Cheeseburger", 180, "Burger"));
r.AddMenuItem(new MenuItem(2, "Kola", 40, "İçecek"));

var customer = new Customer(1, "Alihan", "alihan@example.com", "Istanbul", "0555 000 00 00");
var order = new Order(1001, customer, r);

order.AddItem(r.Menu[0]);
order.AddItem(r.Menu[1]);

// 🔁 Ödeme türünü değiştirerek test et
// PaymentMethod payment = new CashPayment();
var payment = new CreditCardPayment("1234-5678-9012-3456");

order.MakePayment(payment);
order.PrintSummary();
