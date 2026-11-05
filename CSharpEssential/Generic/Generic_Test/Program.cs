namespace Generic_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //泛型的类型定义
            var tp = typeof(List<>);
            Console.WriteLine("泛型的类型定义");
            Console.WriteLine(tp.FullName);
            Console.WriteLine($"List<> IsGenericType: {tp.IsGenericType}");
            Console.WriteLine($"List<> IsGenericTypeDefinition: {tp.IsGenericTypeDefinition}");
            Console.WriteLine($"List<> ContainsGenericParameters: {tp.ContainsGenericParameters}");
            Console.WriteLine($"List<> GetGenericArguments: {tp.GetGenericArguments().First()}");

            //封闭泛型类型
            List<int> intList = new List<int>() { 1, 2, 3 };

            tp = intList.GetType();
            Console.WriteLine("封闭泛型类型");
            Console.WriteLine(tp.FullName);
            Console.WriteLine($"List<int> IsGenericType: {tp.IsGenericType}");
            Console.WriteLine($"List<int> IsGenericTypeDefinition: {tp.IsGenericTypeDefinition}");
            Console.WriteLine($"List<int> ContainsGenericParameters: {tp.ContainsGenericParameters}");
            Console.WriteLine($"List<int> GetGenericArguments: {tp.GetGenericArguments().First()}");
        }
    }
}
