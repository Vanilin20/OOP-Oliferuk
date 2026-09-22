using System;

namespace lab2v16
{
    public class SportTeam
    {
        private string _name;
        private string _coach;
        private int _playersCount;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Coach
        {
            get => _coach;
            set => _coach = value;
        }

        public int PlayersCount
        {
            get => _playersCount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Кількість гравців повинна бути більшою за 0!");
                }
                _playersCount = value;
            }
        }

        public SportTeam(string name, string coach, int playersCount)
        {
            Name = name;
            Coach = coach;
            PlayersCount = playersCount;
            Console.WriteLine($"[Конструктор] Створено команду: {Name}");
        }

        public SportTeam() : this("Team A", "Unknown", 11)
        {
        }

        public void PlayMatch(string opponent)
        {
            Console.WriteLine($"Команда '{Name}' під керівництвом тренера {Coach} грає матч проти '{opponent}'!");
        }

        ~SportTeam()
        {
            Console.WriteLine($"[Деструктор] Об'єкт команди '{_name}' знищено з пам'яті.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Створення об'єктів ===");

            CreateTeams();

            Console.WriteLine("\n=== Об'єкти створено, підготовка до збору сміття (GC) ===");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("=== Завершення роботи програми ===");
        }

        static void CreateTeams()
        {
            SportTeam team1 = new SportTeam();
            team1.PlayMatch("Dynamo");

            SportTeam team2 = new SportTeam("Karpaty", "Myron Markevych", 22);
            team2.PlayMatch("Shakhtar");
        }
    }
}