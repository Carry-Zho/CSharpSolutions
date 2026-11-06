namespace Reflection_NameOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            Print(hello);
        }
        internal static void Print(string printSomething)
        {
            Console.WriteLine(nameof(printSomething));
        }
    }
}
