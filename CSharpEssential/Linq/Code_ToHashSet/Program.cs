namespace Code_ToHashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new[]{1,2,3,4,5,5,4,3,2,1 };
        
            HashSet<int> intSet = numbers.ToHashSet();

            foreach(var item in intSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
