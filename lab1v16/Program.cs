class SportTeam
{
    private string name;
    private string coach;
    private int playersCount;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Coach
    {
        get { return coach; }
        set { coach = value; }
    }

    public int PlayersCount
    {
        get { return playersCount; }
        set { playersCount = value; }
    }

    public SportTeam(string name, string coach, int playersCount)
    {
        this.name = name;
        this.coach = coach;
        this.playersCount = playersCount;
    }

    public void PlayMatch()
    {
        Console.WriteLine($"{name} під керівництвом тренера {coach} виходить на матч у складі {playersCount} гравців.");
    }
}

class Program
{
    static void Main()
    {
        SportTeam team1 = new SportTeam("Динамо", "Іван Петренко", 22);
        SportTeam team2 = new SportTeam("Шахтар", "Олег Коваль", 20);
        SportTeam team3 = new SportTeam("Карпати", "Андрій Мельник", 21);

        team1.PlayMatch();
        team2.PlayMatch();
        team3.PlayMatch();
    }
}