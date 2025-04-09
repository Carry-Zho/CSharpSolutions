namespace Code_18._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();

            Type type = dateTime.GetType();

            foreach (var property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

        }
    }
}
