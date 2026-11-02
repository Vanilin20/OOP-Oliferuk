namespace Lab9v16
{
    // Об'єкт, який перевіряється валідатором
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public User(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }

        public string DisplayName => string.IsNullOrWhiteSpace(Name) ? "(без імені)" : Name;

        public override string ToString()
        {
            return $"{DisplayName} ({Email}, {Age} р.)";
        }
    }
}
