namespace Code_Zip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "Alice", "Bob", "Charlie", "Tongle" };
            var ages = new List<int> { 25, 30, 35 };

            var people = names.Zip(ages, (name, age) =>  (Name:name, Age:age ));

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} is {person.Age} years old.");
            }
        }
    }
}


