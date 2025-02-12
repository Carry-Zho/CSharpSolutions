namespace Enumerable.Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeesCount = PracticeData.Employees.Count();
            var testerCount = PracticeData.Employees.Count(emp=>emp.Title.Equals("Tester"));
            Console.WriteLine("雇员总数量 {0},测试人员总数 {1}", employeesCount, testerCount);
            Console.WriteLine($"雇员总数量 {employeesCount},测试人员总数 {testerCount}");
        }
    }
}