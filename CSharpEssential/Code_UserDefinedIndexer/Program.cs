namespace Code_UserDefinedIndexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pair<string> pair = new("张", "三");
            Console.WriteLine(pair[PairItem.First]);
            Console.WriteLine(pair[PairItem.Second]);
            Console.WriteLine(pair[PairItem.Third]);
        }
    }

    internal enum PairItem
    {
        First,
        Second,
        Third
    }
    internal interface IPair<T>
    {
        T First { get; }
        T Second { get; }
        T this[PairItem index] { get; }
    }
    internal struct Pair<T> : IPair<T>
    {
        public T First { get; }
        public T Second { get; }
        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }
        public T this[PairItem index]
        {
            get
            {
                return index switch
                {
                    PairItem.First => First,
                    PairItem.Second => Second,
                    _ => throw new NotImplementedException($"The enum {index.ToString()} has not been implemented.")
                };
            }
        }
    }
}