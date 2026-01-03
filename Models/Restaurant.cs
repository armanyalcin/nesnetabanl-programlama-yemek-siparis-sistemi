using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Restaurant menüsü
        public List<MenuItem> Menu { get; private set; }

        // Opsiyonel: puan
        public double Rating { get; private set; }
        public int RatingCount { get; private set; }

        public Restaurant(int id, string name)
        {
            Id = id;
            Name = name;
            Menu = new List<MenuItem>();
            Rating = 0;
            RatingCount = 0;
        }

        public void AddMenuItem(MenuItem item)
        {
            Menu.Add(item);
        }

        public void ShowMenu()
        {
            System.Console.WriteLine($"\n--- {Name} Menüsü ---");
            foreach (var item in Menu)
            {
                System.Console.WriteLine(item);
            }
        }

        // Opsiyonel: puan verme
        public void AddRating(int newRating)
        {
            if (newRating < 1) newRating = 1;
            if (newRating > 5) newRating = 5;

            Rating = (Rating * RatingCount + newRating) / (RatingCount + 1);
            RatingCount++;
        }
    }
}
