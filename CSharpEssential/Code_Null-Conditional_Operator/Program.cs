namespace Code_Null_Conditional_Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string token = "Hello world.";

            if (token?.ToString().StartsWith("H") ?? false)
            {
                Console.WriteLine("token is not null and starts with H.");
            }
            else 
            {
                Console.WriteLine("token is null or does not start with H.");
            }
        }
    }
}
