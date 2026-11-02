using System.Diagnostics;
using System.Text;

namespace Lab9v16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Validator validator = new Validator();

            // ===== 1. HashSet: унікальні правила =====
            Console.WriteLine("=== 1. HashSet: унікальні правила валідації ===");
            validator.AddRule(new ValidationRule("NotEmptyName", "ім'я не може бути порожнім",
                u => !string.IsNullOrWhiteSpace(u.Name)));
            validator.AddRule(new ValidationRule("ValidEmail", "email має містити '@'",
                u => u.Email.Contains('@')));
            validator.AddRule(new ValidationRule("AdultAge", "вік має бути від 18",
                u => u.Age >= 18));
            validator.AddRule(new ValidationRule("MaxAge", "вік не може перевищувати 120",
                u => u.Age <= 120));
            validator.AddRule(new ValidationRule("ValidEmail", "дублікат правила",
                u => true));
            validator.PrintRules();

            Console.WriteLine($"  Contains(\"AdultAge\"): {validator.HasRule("AdultAge")}");
            Console.WriteLine($"  Contains(\"PhoneFormat\"): {validator.HasRule("PhoneFormat")}");
            validator.RemoveRule("MaxAge");
            validator.RemoveRule("PhoneFormat");
            validator.PrintRules();

            // ===== 2. Queue: черга об'єктів на валідацію =====
            Console.WriteLine();
            Console.WriteLine("=== 2. Queue: черга об'єктів на валідацію (FIFO) ===");
            validator.EnqueueUser(new User("Іван", "ivan@mail.com", 19));
            validator.EnqueueUser(new User("Олена", "olena.mail.com", 20));
            validator.EnqueueUser(new User("", "anon@mail.com", 25));
            validator.EnqueueUser(new User("Максим", "max-mail", 16));
            validator.PeekNext();
            Console.WriteLine("  Обробка в порядку надходження:");
            validator.ProcessQueue();
            validator.PeekNext();

            // ===== 3. Stack: історія помилок =====
            Console.WriteLine();
            Console.WriteLine("=== 3. Stack: історія помилок валідації (LIFO) ===");
            validator.PrintErrorHistory();
            validator.PeekLastError();
            validator.UndoLastError();
            validator.UndoLastError();
            validator.PrintErrorHistory();

            // ===== 4. Порівняння продуктивності: List vs HashSet =====
            Console.WriteLine();
            Console.WriteLine("=== 4. Продуктивність Contains: List<T> vs HashSet<T> ===");
            ComparePerformance();
        }

        static void ComparePerformance()
        {
            const int size = 100_000;
            const int searches = 1_000;

            List<string> list = new List<string>();
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < size; i++)
            {
                list.Add("Rule" + i);
                set.Add("Rule" + i);
            }

            // Шукаємо елементи з кінця — найгірший випадок для List
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < searches; i++)
                list.Contains("Rule" + (size - 1 - i));
            sw.Stop();
            long listMs = sw.ElapsedMilliseconds;

            sw.Restart();
            for (int i = 0; i < searches; i++)
                set.Contains("Rule" + (size - 1 - i));
            sw.Stop();
            long setMs = sw.ElapsedMilliseconds;

            Console.WriteLine($"  {searches} пошуків серед {size} елементів:");
            Console.WriteLine($"  List<T>.Contains:    {listMs} мс  (O(n) — перебір по черзі)");
            Console.WriteLine($"  HashSet<T>.Contains: {setMs} мс  (O(1) — пошук за хешем)");
        }
    }
}
