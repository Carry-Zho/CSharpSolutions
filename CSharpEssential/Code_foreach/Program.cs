namespace Code_foreach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = 
                new(){ 
                        new(){ Name = "Alice" },
                        new(){ Name = "Bob"} 
                };
            foreach (var person in people)
            {
                people = new() { new() { Name = "Ace" } };
                Console.WriteLine(person.Name);
            }
        }
    }
    class Person 
    { 
        public string Name { get; set; }
    }
}
















