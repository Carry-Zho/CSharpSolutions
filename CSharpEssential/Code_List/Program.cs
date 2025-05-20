namespace Code_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.WriteLine($"List<T>初始化为空集合时的默认容量:{list.Capacity}");
            Console.WriteLine($"List<T>为空集合时的计数:{list.Count}");
            list.Add(1);
            Console.WriteLine($"List<T>初始化为空集合时添加1项元素后的容量:{list.Capacity}");
            Console.WriteLine($"List<T>添加1项元素后的计数:{list.Count}");
        }
    }
}
