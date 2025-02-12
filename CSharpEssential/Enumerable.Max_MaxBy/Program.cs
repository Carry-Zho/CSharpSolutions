namespace Enumerable.Max_MaxBy
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
                ("diaosi", 35,"suzhou")
            };
            var ageMaxPerson = personTupleArray.MaxBy(p=>p.age);
            Console.WriteLine("最长者 {0},年龄 {1},住址 {2}.", ageMaxPerson.name, ageMaxPerson.age, ageMaxPerson.address);
        }
    }





}