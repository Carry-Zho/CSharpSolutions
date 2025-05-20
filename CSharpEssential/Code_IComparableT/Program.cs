namespace Code_IComparableT
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            int number0 = 0;
            int number1 = 1;
            int number2 = 2;            
            
            Console.WriteLine(number1.CompareTo(number0));
            Console.WriteLine(number1.CompareTo(1));
            Console.WriteLine(number1.CompareTo(number2));
        }
    }
}
