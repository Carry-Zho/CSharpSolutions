namespace Enumerable.Append
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
            var appendOnePerson = personTupleArray.Append(("mawu", 35, "henan"));

            personTupleArray[0].name = "xiuzheng";

            foreach (var person in personTupleArray) 
                Console.WriteLine(person.ToString());

            Console.WriteLine("******************************");

            foreach(var person in appendOnePerson) 
                Console.WriteLine(person.ToString());
        }
    }
}
