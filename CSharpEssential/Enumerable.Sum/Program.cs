namespace Enumerable.Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string name, int age, string address)[] personTupleArray =
                {
                ("zhangsan", 21,"henan"),
                ("lisi", 22,"beijing"),
                ("wangwu", 23,"hebei"),
                ("maliu", 24,"shanghai"),
                ("diaosi", 36,"suzhou")
                };

            Console.WriteLine("年龄加总为 {0}", personTupleArray.Sum(person=>person.age));
        }
    }
}
