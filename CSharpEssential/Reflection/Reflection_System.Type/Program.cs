namespace Reflection_System.Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dateTimeType = new DateTime();
            var typeDescriptor = dateTimeType.GetType();
            foreach (var property in typeDescriptor.GetProperties())
            {
                Console.WriteLine(property.Name);
            }
        }
    }
}
