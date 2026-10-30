namespace Lab8v16
{
    public static class CollectionHelper<T>
    {
        // Об'єднує дві колекції попарно, застосовуючи resultSelector до кожної пари.
        // Довжина результату дорівнює довжині коротшої колекції.
        public static IEnumerable<TResult> Zip<TSecond, TResult>(
            IEnumerable<T> first,
            IEnumerable<TSecond> second,
            Func<T, TSecond, TResult> resultSelector)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (resultSelector == null)
                throw new ArgumentNullException(nameof(resultSelector));

            List<TResult> result = new List<TResult>();

            using (IEnumerator<T> firstEnumerator = first.GetEnumerator())
            using (IEnumerator<TSecond> secondEnumerator = second.GetEnumerator())
            {
                while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                {
                    result.Add(resultSelector(firstEnumerator.Current, secondEnumerator.Current));
                }
            }

            return result;
        }
    }
}
