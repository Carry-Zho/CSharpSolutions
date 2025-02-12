namespace Enumerable.Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var depEmps = PracticeData.Departments.Join(PracticeData.Employees,
                dep => dep.DepartmentId,
                emp => emp.DepartmentId,
                (dep, emp) => new
                {
                    DepartmentName = dep.DepartmentName,
                    EmployeeName = emp.EmployeeName
                });
            foreach (var depEmp in depEmps)
            {
                Console.WriteLine($"Department Name: {depEmp.DepartmentName}, Employee Name: {depEmp.EmployeeName}");
            }
        }
    }
}
