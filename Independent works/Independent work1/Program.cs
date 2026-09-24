namespace IndependentWork1
{
    public class Rectangle
    {
        private double _length;
        private double _width;

        public double Width => _width;

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public Rectangle(double length, double width)
        {
            _length = length;
            _width = width;
        }

        public double CalculateArea()
        {
            return _length * _width;
        }
    }

    public class Book
    {
        private string _title;
        private int _pages;
        private bool _isRead;

        public string Title => _title;
        public int Pages => _pages;
        public bool IsRead => _isRead;

        public Book(string title, int pages)
        {
            _title = title;
            _pages = pages;
            _isRead = false;
        }

        public void MarkAsRead()
        {
            _isRead = true;
            Console.WriteLine($"Книгу \"{_title}\" позначено як прочитану!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== ДЕМОНСТРАЦІЯ РОБОТИ КЛАСІВ ===\n");

            Console.WriteLine("--- Робота з прямокутником ---");
            Console.Write("Введіть ширину прямокутника: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Введіть довжину прямокутника: ");
            double length = double.Parse(Console.ReadLine());

            Rectangle rect = new Rectangle(length, width);

            Console.WriteLine($"Створено прямокутник розміром: {rect.Width} x {rect.Length}");
            Console.WriteLine($"Площа прямокутника: {rect.CalculateArea()}\n");

            Console.WriteLine("--- Робота з книгою ---");
            Console.Write("Введіть назву книги: ");
            string title = Console.ReadLine();

            Console.Write("Введіть кількість сторінок: ");
            int pages = int.Parse(Console.ReadLine());

            Book book = new Book(title, pages);

            Console.WriteLine($"\nКнига: \"{book.Title}\", сторінок: {book.Pages}");
            Console.WriteLine($"Статус прочитання до виклику методу: {(book.IsRead ? "Прочитано" : "Не прочитано")}");

            book.MarkAsRead();

            Console.WriteLine($"Статус прочитання після виклику методу: {(book.IsRead ? "Прочитано" : "Не прочитано")}");

            Console.WriteLine("\nПрограму успішно виконано!");
        }
    }
}