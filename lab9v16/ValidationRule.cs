namespace Lab9v16
{
    // Правило валідації. Два правила вважаються однаковими, якщо мають однакову назву,
    // тому HashSet не дозволить додати правило з тією самою назвою двічі.
    public class ValidationRule
    {
        public string Name { get; }
        public string ErrorMessage { get; }
        public Func<User, bool> Check { get; }

        public ValidationRule(string name, string errorMessage, Func<User, bool> check)
        {
            Name = name;
            ErrorMessage = errorMessage;
            Check = check;
        }

        public override bool Equals(object? obj)
        {
            return obj is ValidationRule other && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
