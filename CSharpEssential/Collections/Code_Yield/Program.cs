namespace Code_Yield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var keywords = new CSharpBuildInTypes();
            foreach (var keyword in keywords)
            {
                Console.WriteLine(keyword);
            }
        }
    }
    internal class CSharpBuildInTypes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "int";
            yield return "long";
            yield return "float";
            yield return "double";
        }
        //IEnumerable<string>接口继承System.Collections.IEnumerable接口，因此实现IEnumerable<string>要求
        //必须同时实现泛型的System.Collections.Generic.IEnumerable<string>接口和非泛型的System.Collections.IEnumerable接口
        //已定义泛型的GetEnumerator方法，非泛型的GetEnumerator方法必须显式实现
        //非泛型的GetEnumerator方法不需要使用yield return语句，其内返回泛型的GetEnumerator方法即可
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            //内部调用泛型GetEnumerator方法
            return GetEnumerator();
        }
    }
}
