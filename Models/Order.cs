using System;
using System.Collections.Generic;
using FoodOrderingSystem.Interfaces;

namespace FoodOrderingSystem.Models
{
    public class Order : Orderable
    {
        public int Id { get; set; }
        public Customer Customer { get; private set; }
        public Restaurant Restaurant { get; private set; }

        public List<MenuItem> Items { get; private set; }

        public DateTime CreatedAt { get; private set; }

        // Sipariş durumu (Türkçe)
        public string Status { get; private set; }

        public Order(int id, Customer customer, Restaurant restaurant)
        {
            Id = id;
            Customer = customer;
            Restaurant = restaurant;

            Items = new List<MenuItem>();
            CreatedAt = DateTime.Now;
            Status = "Oluşturuldu";
        }

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(int menuItemId)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Id == menuItemId)
                {
                    Items.RemoveAt(i);
                    return;
                }
            }
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        }

        public void PrintSummary()
        {
            Console.WriteLine("\n--- Sipariş Özeti ---");
            Console.WriteLine($"Sipariş No: {Id}");
            Console.WriteLine($"Müşteri: {Customer.Name}");
            Console.WriteLine($"Restoran: {Restaurant.Name}");
            Console.WriteLine($"Durum: {Status}");
            Console.WriteLine($"Oluşturulma Zamanı: {CreatedAt}");

            Console.WriteLine("\nÜrünler:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item.Name} ({item.Price} TL)");
            }

            Console.WriteLine($"\nToplam Tutar: {CalculateTotal()} TL");
        }

        // Durum değiştiren metotlar (okunaklı ve basit)
        public void OdemeAlindi()
        {
            Status = "Ödeme Alındı";
        }

        public void Hazirlaniyor()
        {
            Status = "Hazırlanıyor";
        }

        public void YolaCikti()
        {
            Status = "Yolda";
        }

        public void TeslimEdildi()
        {
            Status = "Teslim Edildi";
        }

        public void IptalEt()
        {
            Status = "İptal Edildi";
        }
    }
}
