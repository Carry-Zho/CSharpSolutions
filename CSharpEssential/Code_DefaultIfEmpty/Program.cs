namespace Code_DefaultIfEmpty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new() { 
                new() { Name="小黄狗",Age = 5},
                new() { Name="小白猫",Age = 3},
                new() { Name="大老虎",Age = 1},
            };
            foreach (var pet in pets.DefaultIfEmpty())
            {
                Console.WriteLine($"宠物的名字是：{pet.Name}，年龄是：{pet.Age}");
            }

            foreach (var pet in pets.Where(pt => pt.Age > 5).DefaultIfEmpty())
            {
                Console.WriteLine(pet == null);
            }

            List<int> numbers = new() { 4,5,6 };
            
            foreach (var number in numbers.Where(n => n < 4).DefaultIfEmpty())
            {
                Console.WriteLine(number);
            }

        }
    }
    internal class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}






