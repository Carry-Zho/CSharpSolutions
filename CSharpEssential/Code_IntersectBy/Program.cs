using System.Linq;

namespace Code_IntersectBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees1 = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice" },
                new Employee { Id = 2, Name = "Bob" },
                new Employee { Id = 3, Name = "Charlie" }
            };
            var employees2 = new[]
            {
                new Employee { Id = 2, Name = "Bob" },
                new Employee { Id = 3, Name = "Charlie" },
                new Employee { Id = 4, Name = "David" }
            };
            //假设我们有两个员工列表，基于员工的 Id 查找两个集合中的交集。
            var intersectEmployees = employees1.IntersectBy(employees2.Select(item =>item.Id), emp => emp.Id);

            foreach (var emp in intersectEmployees)
            {
                Console.WriteLine($"员工ID {emp.Id} 员工姓名 {emp.Name}");
            }
        }
    }
    internal class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
