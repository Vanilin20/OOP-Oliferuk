using System.Text;

namespace Lab8v16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 1. List<string> (імена) + List<int> (вік) -> List<string>
            Console.WriteLine("=== 1. Імена + вік -> рядки ===");
            List<string> names = new List<string> { "Іван", "Андрій", "Олена", "Марія" };
            List<int> ages = new List<int> { 19, 18, 20, 17 };

            IEnumerable<string> people = CollectionHelper<string>.Zip(
                names, ages, (name, age) => $"{name} — {age} років");

            foreach (string person in people)
                Console.WriteLine(person);

            // 2. List<int> + List<int> -> List<int> (поелементна сума)
            Console.WriteLine();
            Console.WriteLine("=== 2. Поелементна сума двох List<int> ===");
            List<int> a = new List<int> { 1, 2, 3, 4, 5 };
            List<int> b = new List<int> { 10, 20, 30, 40, 50 };

            IEnumerable<int> sums = CollectionHelper<int>.Zip(a, b, (x, y) => x + y);
            Console.WriteLine(string.Join(", ", sums));

            // 3. List<Product> + List<int> (кількість) -> List<string> (вартість позиції)
            Console.WriteLine();
            Console.WriteLine("=== 3. Продукти + кількість -> вартість ===");
            List<Product> products = new List<Product>
            {
                new Product(1, "Ноутбук", 25000m),
                new Product(2, "Мишка", 450m),
                new Product(3, "Клавіатура", 1200m)
            };
            List<int> quantities = new List<int> { 1, 3, 2 };

            IEnumerable<string> orderLines = CollectionHelper<Product>.Zip(
                products, quantities,
                (product, qty) => $"{product.Name}: {qty} x {product.Price} = {product.Price * qty} грн");

            foreach (string line in orderLines)
                Console.WriteLine(line);

            // 4. Граничний випадок: колекції різної довжини
            Console.WriteLine();
            Console.WriteLine("=== 4. Колекції різної довжини ===");
            List<string> letters = new List<string> { "A", "B", "C", "D", "E" };
            List<int> numbers = new List<int> { 1, 2, 3 };

            IEnumerable<string> pairs = CollectionHelper<string>.Zip(
                letters, numbers, (letter, number) => letter + number);
            Console.WriteLine($"Перша: {letters.Count} ел., друга: {numbers.Count} ел.");
            Console.WriteLine("Результат: " + string.Join(", ", pairs));

            // 5. Граничний випадок: порожня колекція
            Console.WriteLine();
            Console.WriteLine("=== 5. Порожня колекція ===");
            IEnumerable<string> empty = CollectionHelper<string>.Zip(
                new List<string>(), ages, (name, age) => name + age);
            Console.WriteLine($"Кількість елементів результату: {empty.Count()}");
        }
    }
}
