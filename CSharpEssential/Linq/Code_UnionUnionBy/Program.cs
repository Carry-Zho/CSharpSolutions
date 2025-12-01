namespace Code_UnionUnionBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //假设我们有两个员工列表，部分员工在两个列表中重复，希望根据员工的 ID 合并去重。
            Employee[] employees1 = { 
                new Employee { Id = 1, Name = "Alice" },
                new Employee { Id = 2, Name = "Bob" }};

            IEnumerable<Employee> employees2 = new[]{ 
                new Employee { Id = 2, Name = "Bob,Robert" },
                new Employee { Id = 3, Name = "Charlie" }};

            var result = employees1.UnionBy(employees2, e => e.Id);

            foreach (var emp in result)
                Console.WriteLine($"员工ID{emp.Id} 员工姓名{emp.Name}");
        }
    }
    internal class Employee
    { 
        public int Id { get; set; }
        public string? Name { get; set; }
    }   
}
