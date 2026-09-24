namespace IndependentWork2
{
    public class Product
    {
        public string Name { get; }
        public double Price { get; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double GetSubtotal()
        {
            return Product.Price * Quantity;
        }

        public double GetDiscount()
        {
            if (Product.Price > 500.0)
            {
                return GetSubtotal() * 0.10;
            }
            return 0;
        }

        public double GetTotal()
        {
            return GetSubtotal() - GetDiscount();
        }
    }

    public class Cart
    {
        private List<CartItem> _items = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            _items.Add(new CartItem(product, quantity));
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in _items)
            {
                total += item.GetTotal();
            }
            return total;
        }

        public void PrintCart()
        {
            Console.WriteLine("=== ОБ'ЄКТНО-ОРІЄНТОВАНИЙ ПІДХІД ===");
            foreach (var item in _items)
            {
                Console.WriteLine($"Товар: {item.Product.Name} | Ціна: {item.Product.Price} грн | Кількість: {item.Quantity} | Сума: {item.GetSubtotal()} грн | Знижка: {item.GetDiscount()} грн");
            }
            Console.WriteLine($"Загальна сума кошика: {GetTotal()} грн\n");
        }
    }
}