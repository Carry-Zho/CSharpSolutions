namespace Enumerable.Distinct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ages = new() { 17, 21, 21, 46, 46, 55, 55, 55 };
            IEnumerable<int> distinctAges = ages.Distinct();
            foreach (int age in distinctAges) 
            {
                Console.WriteLine(age);
            }
        }
    }
}


