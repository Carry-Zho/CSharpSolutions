using System.Collections;
namespace Enumerable.OfType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList fruits = new() 
            {
                "Mango",
                "Orange",
                null,
                "Apple",
                3.0,
                "Banana"
            };
            var query1 = fruits.OfType<string>();
            foreach(var fr in query1) 
            {
                Console.WriteLine(fr);
            }
        }
    }
}






