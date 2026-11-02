namespace Lab9v16
{
    // Запис про помилку валідації, що зберігається в історії
    public class ValidationError
    {
        public string UserName { get; }
        public string RuleName { get; }
        public string Message { get; }

        public ValidationError(string userName, string ruleName, string message)
        {
            UserName = userName;
            RuleName = ruleName;
            Message = message;
        }

        public override string ToString()
        {
            return $"[{RuleName}] {UserName}: {Message}";
        }
    }
}
