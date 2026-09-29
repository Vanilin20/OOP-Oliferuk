using System;

namespace IndependentWork3
{
    public class SensorReader : IDisposable
    {
        private readonly int _sensorId;
        private bool _isReading;
        private bool _disposed = false;

        public int SensorId => _sensorId;
        public bool IsReading => _isReading;

        public SensorReader(int sensorId)
        {
            _sensorId = sensorId;
            _isReading = true;
            Console.WriteLine($"[Сенсор #{_sensorId}]: Запущено читання даних.");
        }

        public void ReadValue()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(SensorReader), $"Сенсор #{_sensorId} закрито. Читання неможливе.");

            if (_isReading)
            {
                double value = new Random().NextDouble() * 100.0;
                Console.WriteLine($"[Сенсор #{_sensorId}]: Отримано значення = {value:F2}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"[Dispose(true)] Сенсор #{_sensorId}: Звільнення керованих ресурсів.");
                }

                if (_isReading)
                {
                    Console.WriteLine($"[Dispose] Сенсор #{_sensorId}: Зупинено читання (звільнення ресурсу).");
                    _isReading = false;
                }

                _disposed = true;
            }
        }

        ~SensorReader()
        {
            Console.WriteLine($"[Деструктор]: Виклик для Сенсора #{_sensorId}");
            Dispose(false);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== СЦЕНАРІЙ 1: Використання оператора using ===");
            Scenario1_Using();

            Console.WriteLine("\n=== СЦЕНАРІЙ 2: Явний виклик Dispose() ===");
            Scenario2_ExplicitDispose();

            Console.WriteLine("\n=== СЦЕНАРІЙ 3: Об'єкт без Dispose (робота GC) ===");
            Scenario3_GarbageCollector();

            Console.WriteLine("\nПрограма завершила роботу.");
        }

        static void Scenario1_Using()
        {
            using (var sensor = new SensorReader(101))
            {
                sensor.ReadValue();
            }
        }

        static void Scenario2_ExplicitDispose()
        {
            var sensor = new SensorReader(202);
            sensor.ReadValue();
            sensor.Dispose();
        }

        static void Scenario3_GarbageCollector()
        {
            void CreateUnreferencedSensor()
            {
                var sensor = new SensorReader(303);
                sensor.ReadValue();
            }

            CreateUnreferencedSensor();

            Console.WriteLine("Запуск GC.Collect()...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}