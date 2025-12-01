namespace Code_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 10).Select(num => num*num);
            var enumerator = numbers.GetEnumerator();
            int index = 1;
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine($"数字{index}的平方数是{enumerator.Current}");
                index++;
            }
        }
    }
}




