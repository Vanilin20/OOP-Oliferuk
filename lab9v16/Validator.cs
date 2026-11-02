namespace Lab9v16
{
    public class Validator
    {
        // HashSet: унікальні правила валідації
        private readonly HashSet<ValidationRule> _rules = new HashSet<ValidationRule>();

        // Queue: черга об'єктів на валідацію (FIFO)
        private readonly Queue<User> _queue = new Queue<User>();

        // Stack: історія помилок валідації (LIFO)
        private readonly Stack<ValidationError> _errorHistory = new Stack<ValidationError>();

        // ===== HashSet =====

        public bool AddRule(ValidationRule rule)
        {
            bool added = _rules.Add(rule);
            Console.WriteLine(added
                ? $"  + Правило \"{rule.Name}\" додано"
                : $"  ! Правило \"{rule.Name}\" вже існує — дублікат не додано");
            return added;
        }

        public bool RemoveRule(string ruleName)
        {
            bool removed = _rules.RemoveWhere(r => r.Name == ruleName) > 0;
            Console.WriteLine(removed
                ? $"  - Правило \"{ruleName}\" видалено"
                : $"  ! Правила \"{ruleName}\" не знайдено");
            return removed;
        }

        public bool HasRule(string ruleName)
        {
            // Contains шукає за хешем назви — O(1) в середньому
            return _rules.Contains(new ValidationRule(ruleName, "", _ => true));
        }

        public void PrintRules()
        {
            Console.WriteLine($"  Активні правила ({_rules.Count}): " +
                string.Join(", ", _rules.Select(r => r.Name)));
        }

        // ===== Queue =====

        public void EnqueueUser(User user)
        {
            _queue.Enqueue(user);
            Console.WriteLine($"  -> У чергу додано: {user.DisplayName} (у черзі: {_queue.Count})");
        }

        public void PeekNext()
        {
            if (_queue.Count > 0)
                Console.WriteLine($"  Peek: наступним буде перевірено {_queue.Peek().DisplayName}");
            else
                Console.WriteLine("  Peek: черга порожня");
        }

        public void ProcessQueue()
        {
            int order = 1;
            while (_queue.Count > 0)
            {
                User user = _queue.Dequeue();
                Console.WriteLine($"  {order}. Dequeue: {user}");

                bool isValid = true;
                foreach (ValidationRule rule in _rules)
                {
                    if (!rule.Check(user))
                    {
                        isValid = false;
                        ValidationError error = new ValidationError(user.DisplayName, rule.Name, rule.ErrorMessage);
                        _errorHistory.Push(error);
                        Console.WriteLine($"       x {rule.Name}: {rule.ErrorMessage}");
                    }
                }

                if (isValid)
                    Console.WriteLine("       OK: усі правила пройдено");

                order++;
            }
            Console.WriteLine($"  Черга оброблена, залишилось: {_queue.Count}");
        }

        // ===== Stack =====

        public void PeekLastError()
        {
            if (_errorHistory.Count > 0)
                Console.WriteLine($"  Peek: остання помилка — {_errorHistory.Peek()}");
            else
                Console.WriteLine("  Peek: історія помилок порожня");
        }

        public void UndoLastError()
        {
            if (_errorHistory.Count > 0)
            {
                ValidationError error = _errorHistory.Pop();
                Console.WriteLine($"  Pop (Undo): прибрано {error}");
            }
            else
            {
                Console.WriteLine("  Pop: історія помилок порожня");
            }
        }

        public void PrintErrorHistory()
        {
            Console.WriteLine($"  Історія помилок ({_errorHistory.Count}), від найновішої:");
            foreach (ValidationError error in _errorHistory)
                Console.WriteLine($"    {error}");
        }
    }
}
