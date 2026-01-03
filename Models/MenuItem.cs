namespace FoodOrderingSystem.Models
{
    public class MenuItem
    {
        public int Id { get; set; }            // seçim yaparken kolaylık
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public MenuItem(int id, string name, double price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id}) {Name} - {Price} TL ({Category})";
        }
    }
}
