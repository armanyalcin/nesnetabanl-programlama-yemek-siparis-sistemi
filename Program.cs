using System;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Interfaces;

static int ReadInt(string msg)
{
    Console.Write(msg);
    var input = Console.ReadLine();
    int val;
    while (!int.TryParse(input, out val))
    {
        Console.Write("Hatalı giriş. Tekrar: ");
        input = Console.ReadLine();
    }
    return val;
}

static string ReadString(string msg)
{
    Console.Write(msg);
    return Console.ReadLine() ?? "";
}

static void PrintCart(Order order)
{
    Console.WriteLine("\n--- Sepet ---");
    if (order.Items.Count == 0)
    {
        Console.WriteLine("Sepet boş.");
        return;
    }

    foreach (var it in order.Items)
        Console.WriteLine($"- {it.Id}) {it.Name} ({it.Price} TL)");

    Console.WriteLine($"Toplam: {order.CalculateTotal()} TL");
}

var restaurant = new Restaurant(1, "Burger Kral");
restaurant.AddMenuItem(new MenuItem(1, "Cheeseburger", 180, "Burger"));
restaurant.AddMenuItem(new MenuItem(2, "Tavuk Burger", 170, "Burger"));
restaurant.AddMenuItem(new MenuItem(3, "Patates Kızartması", 70, "Yan Ürün"));
restaurant.AddMenuItem(new MenuItem(4, "Kola", 40, "İçecek"));
restaurant.AddMenuItem(new MenuItem(5, "Ayran", 25, "İçecek"));

Console.WriteLine("=== Yemek Sipariş Sistemi ===");

var name = ReadString("Ad Soyad: ");
var email = ReadString("Email: ");
var address = ReadString("Adres: ");
var phone = ReadString("Telefon: ");

var customer = new Customer(1, name, email, address, phone);
var order = new Order(1001, customer, restaurant);

bool running = true;

while (running)
{
    Console.WriteLine("\n--- MENÜ ---");
    Console.WriteLine("1) Restoran menüsünü göster");
    Console.WriteLine("2) Sepete ürün ekle");
    Console.WriteLine("3) Sepetten ürün çıkar");
    Console.WriteLine("4) Sepeti göster");
    Console.WriteLine("5) Siparişi tamamla (Ödeme)");
    Console.WriteLine("6) Sipariş özetini göster");
    Console.WriteLine("0) Çıkış");

    int choice = ReadInt("Seçim: ");

    switch (choice)
    {
        case 1:
            restaurant.ShowMenu();
            break;

        case 2:
        {
            restaurant.ShowMenu();
            int id = ReadInt("Sepete eklenecek ürün id: ");

            var found = restaurant.Menu.Find(x => x.Id == id);
            if (found == null)
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
            else
            {
                order.AddItem(found);
                Console.WriteLine($"Eklendi: {found.Name}");
            }
            break;
        }

        case 3:
        {
            PrintCart(order);
            int id = ReadInt("Sepetten çıkarılacak ürün id: ");
            order.RemoveItem(id);
            Console.WriteLine("İşlem tamam.");
            break;
        }

        case 4:
            PrintCart(order);
            break;

        case 5:
        {
            if (order.Items.Count == 0)
            {
                Console.WriteLine("Sepet boş. Önce ürün ekle.");
                break;
            }

            Console.WriteLine("\nÖdeme Yöntemi Seç:");
            Console.WriteLine("1) Nakit");
            Console.WriteLine("2) Kredi Kartı");

            int p = ReadInt("Seçim: ");

            PaymentMethod payment;
            if (p == 1)
            {
                payment = new CashPayment();
            }
            else if (p == 2)
            {
                var cardNo = ReadString("Kart No (ör: 1234-5678-9012-3456): ");
                payment = new CreditCardPayment(cardNo);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
                break;
            }

            order.MakePayment(payment);
            Console.WriteLine($"Ödeme yöntemi: {payment.GetPaymentType()}");
            Console.WriteLine("Sipariş tamamlandı ✅");
            break;
        }

        case 6:
            order.PrintSummary();
            break;

        case 0:
            running = false;
            break;

        default:
            Console.WriteLine("Geçersiz seçim.");
            break;
    }
}

Console.WriteLine("Çıkış yapıldı.");
