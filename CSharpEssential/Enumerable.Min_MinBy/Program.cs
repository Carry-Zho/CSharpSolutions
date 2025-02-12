namespace Enumerable.Min_MinBy
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
                ("diaosi", 35,"jiangsu"),
                ("piqi", 21,"zhejiang")
            };
            var ageMinPerson = personTupleArray.MinBy(p => p.age);
            Console.WriteLine("最长者 {0},年龄 {1},住址 {2}.", ageMinPerson.name, ageMinPerson.age, ageMinPerson.address);
        }
    }
}



