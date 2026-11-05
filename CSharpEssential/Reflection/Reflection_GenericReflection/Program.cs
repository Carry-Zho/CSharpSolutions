namespace Reflection_GenericReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type tp = typeof(System.Nullable<>);

            //Console.WriteLine($"System.Nullable<> 是否是泛型类型: {tp.IsGenericType}");
            //Console.WriteLine($"System.Nullable<> 是否具有尚未被特定类型替换的类型参数: {tp.ContainsGenericParameters}");

            //tp = typeof(int?);
            //Console.WriteLine($"typeof(int?) == typeof(System.Nullable<int>):{typeof(int?) == typeof(System.Nullable<int>)}");

            //Console.WriteLine($"System.Nullable<int> 是否是泛型类型: {tp.IsGenericType}");
            //Console.WriteLine($"System.Nullable<int> 是否具有尚未被特定类型替换的类型参数: {tp.ContainsGenericParameters}");

            Dictionary<string, object> dic = new Dictionary<string, object>();

            tp = dic.GetType();

            foreach (var typeArgument in tp.GetGenericArguments())
            {
                Console.WriteLine($"Type argument:{typeArgument.Name}");
            }
        }
    }
}
