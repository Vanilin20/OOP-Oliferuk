namespace IndependentWork2
{
    public static class ProceduralDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== ПРОЦЕДУРНИЙ ПІДХІД ===");

            string[] names = { "Ноутбук", "Мишка", "Клавіатура" };
            double[] prices = { 25000.0, 450.0, 800.0 };
            int[] quantities = { 1, 2, 1 };

            double[] itemTotals = CalculateItemTotals(prices, quantities);
            double[] discounts = ApplyDiscounts(prices, itemTotals);
            double grandTotal = CalculateGrandTotal(itemTotals, discounts);

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Товар: {names[i]} | Ціна: {prices[i]} грн | Кількість: {quantities[i]} | Сума: {itemTotals[i]} грн | Знижка: {discounts[i]} грн");
            }

            Console.WriteLine($"Загальна сума кошика: {grandTotal} грн\n");
        }

        public static double[] CalculateItemTotals(double[] prices, int[] quantities)
        {
            double[] totals = new double[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                totals[i] = prices[i] * quantities[i];
            }
            return totals;
        }

        public static double[] ApplyDiscounts(double[] prices, double[] itemTotals)
        {
            double[] discounts = new double[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] > 500.0)
                {
                    discounts[i] = itemTotals[i] * 0.10;
                }
                else
                {
                    discounts[i] = 0;
                }
            }
            return discounts;
        }

        public static double CalculateGrandTotal(double[] itemTotals, double[] discounts)
        {
            double grandTotal = 0;
            for (int i = 0; i < itemTotals.Length; i++)
            {
                grandTotal += (itemTotals[i] - discounts[i]);
            }
            return grandTotal;
        }
    }
}