namespace Enumerable.DistinctBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string name, int age, string address)[] personTupleArray =
            {
                ("zhangsan", 21,"henan"),
                ("lisi", 21,"beijing"),
                ("wangwu", 22,"hebei"),
                ("maliu", 22,"shanghai"),
                ("diaosi", 22,"suzhou")
            };
            var distinctPersonByAge = personTupleArray.DistinctBy(person=>person.age);

            foreach (var person in distinctPersonByAge)
                Console.WriteLine(person);

        }
    }
}



