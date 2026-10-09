using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Колекція базового типу
List<User> users = new List<User>
{
    new Admin("root", "IT"),
    new Moderator("mod_anna", "Games"),
    new Guest("guest_01", "S-1001")
};

// Поліморфний виклик для кожного об'єкта
foreach (User u in users)
    u.GetPermissions();

// Агрегація: список усіх дозволів
List<string> allPermissions = new List<string>();
foreach (User u in users)
    allPermissions.AddRange(u.Permissions);

Console.WriteLine();
Console.WriteLine($"Усі дозволи ({allPermissions.Count}):");
foreach (string p in allPermissions)
    Console.WriteLine($"- {p}");

class User
{
    private string _username;
    public string Username { get => _username; set => _username = value; }
    public List<string> Permissions { get; } = new List<string>();

    public User(string username)
    {
        _username = username;
    }

    public virtual void GetPermissions()
    {
        Permissions.Clear();
        Permissions.Add("немає дозволів");
        Console.WriteLine($"[User: {Username}] {string.Join(", ", Permissions)}");
    }
}

class Admin : User
{
    private string _department;
    public string Department { get => _department; set => _department = value; }

    public Admin(string username, string department) : base(username)
    {
        _department = department;
    }

    public override void GetPermissions()
    {
        Permissions.Clear();
        Permissions.Add("керувати користувачами");
        Permissions.Add("змінювати налаштування");
        Permissions.Add("видаляти будь-який контент");
        Console.WriteLine($"[Admin: {Username}, відділ {Department}] {string.Join(", ", Permissions)}");
    }
}

class Moderator : User
{
    private string _forumName;
    public string ForumName { get => _forumName; set => _forumName = value; }

    public Moderator(string username, string forumName) : base(username)
    {
        _forumName = forumName;
    }

    public override void GetPermissions()
    {
        Permissions.Clear();
        Permissions.Add($"видаляти повідомлення на форумі {ForumName}");
        Permissions.Add("блокувати порушників");
        Console.WriteLine($"[Moderator: {Username}, форум {ForumName}] {string.Join(", ", Permissions)}");
    }
}

class Guest : User
{
    private string _sessionId;
    public string SessionId { get => _sessionId; set => _sessionId = value; }

    public Guest(string username, string sessionId) : base(username)
    {
        _sessionId = sessionId;
    }

    public override void GetPermissions()
    {
        Permissions.Clear();
        Permissions.Add("переглядати публічний контент");
        Console.WriteLine($"[Guest: {Username}, сесія {SessionId}] {string.Join(", ", Permissions)}");
    }
}