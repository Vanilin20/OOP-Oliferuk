namespace IndependentWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Виклик процедурної версії
            ProceduralDemo.Run();

            // 2. Виклик об'єктно-орієнтованої версії
            Cart cart = new Cart();
            cart.AddItem(new Product("Ноутбук", 25000.0), 1);
            cart.AddItem(new Product("Мишка", 450.0), 2);
            cart.AddItem(new Product("Клавіатура", 800.0), 1);

            cart.PrintCart();
        }
    }
}