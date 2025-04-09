namespace LINQ_ElementAt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> dic = new() 
            {
                ["Zhang"] = 1,
                ["Li"] = 2,
                ["Wang"] = 3,
                ["Zhao"] = 4,
                ["La"] = 2
            };

            //不要依赖未实现IList<T>接口集合的元素顺序
            var secondItem = dic.ElementAt(1);
            // 可能是任意一个键值对
            Console.WriteLine($"LINQ ElementAt 1 {secondItem.Key}:{secondItem.Value}");
        }

    }
}