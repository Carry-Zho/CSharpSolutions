namespace Enumerable.Average
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

            var averageAge = personTupleArray.Average(person => person.age);

            Console.WriteLine("人员平均年龄 {0}", averageAge);

        }
    }
}
