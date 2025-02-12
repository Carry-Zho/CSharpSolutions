namespace Enumerable.GroupJoin
{
    internal class Department
    {
        //声明DepartmentId、DepartmentName属性的支持字段
        private string _DepartmentId = string.Empty;
        private string _DepartmentName = string.Empty;

        //声明DepartmentId、DepartmentName属性，并添加set验证
        public string DepartmentId
        {
            get => _DepartmentId;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("DepartmentId cannot be null or empty");
                }
                else 
                {
                    _DepartmentId = value;
                }
            }
        }
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("DepartmentName cannot be null or empty");
                }
                else
                {
                    _DepartmentName = value;
                }
            }
        }
        //重写ToString方法
        public override string ToString()
        {
            return @$"Department Id is {DepartmentId}, department name is {DepartmentName}.
Welcome.";   //使用字符串逐字，使用插值字符串
        }
    }
    internal class Employee
    {
        //声明EmployeeId、EmployeeName、DepartmentId属性的支持字段
        private string _EmployeeId = string.Empty;
        private string _EmployeeName = string.Empty;
        private string _DepartmentId = string.Empty;

        //声明EmployeeId、EmployeeName、DepartmentId属性，并添加set验证
        public string EmployeeId
        {
            get => _EmployeeId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("EmployeeId cannot be null or empty");
                else
                    _EmployeeId = value;
            }
        }
        public string EmployeeName
        {
            get => _EmployeeName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("EmployeeName cannot be null or empty");
                else
                    _EmployeeName = value;
            }
        }
        public string DepartmentId
        {
            get 
            { 
                return _DepartmentId; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("DepartmentId cannot be null or empty");
                else
                    _DepartmentId = value;
            }
        }

        //声明Title属性
        public string Title { get; set; } = string.Empty;

        //重写ToString方法
        public override string ToString()
        {
            return $@"Employee Id is {EmployeeId}, employee name is {EmployeeName}, title is {Title}.
Well done.";
        }
    }
    internal class PracticeData
    {
        public static Department[] Departments = new Department[]
        {
            new Department() { DepartmentId = "0001", DepartmentName = "运维部" },
            new Department() { DepartmentId = "0002", DepartmentName = "开发部" },
            new Department() { DepartmentId = "0003", DepartmentName = "测试部" }
        };
        public static Employee[] Employees = new Employee[]
        {
            new Employee() { EmployeeId = "0001", EmployeeName = "张三", DepartmentId = "0001", Title = "Manager" },
            new Employee() { EmployeeId = "0002", EmployeeName = "李四", DepartmentId = "0002", Title = "Developer" },
            new Employee() { EmployeeId = "0003", EmployeeName = "王五", DepartmentId = "0003", Title = "Tester" },
            new Employee() { EmployeeId = "0004", EmployeeName = "赵六", DepartmentId = "0001", Title = "Manager" },
            new Employee() { EmployeeId = "0005", EmployeeName = "孙七", DepartmentId = "0002", Title = "Developer" },
            new Employee() { EmployeeId = "0006", EmployeeName = "周八", DepartmentId = "0003", Title = "Tester" },
            new Employee() { EmployeeId = "0007", EmployeeName = "吴九", DepartmentId = "0001", Title = "Manager" },
            new Employee() { EmployeeId = "0008", EmployeeName = "郑十", DepartmentId = "0002", Title = "Developer" },
            new Employee() { EmployeeId = "0009", EmployeeName = "钱十一", DepartmentId = "0003", Title = "Tester" },
            new Employee() { EmployeeId = "0010", EmployeeName = "孔十二", DepartmentId = "0001", Title = "Manager" },
            new Employee() { EmployeeId = "0011", EmployeeName = "曹十三", DepartmentId = "0002", Title = "Developer" },
            new Employee() { EmployeeId = "0012", EmployeeName = "秦十四", DepartmentId = "0003", Title = "Tester" },
            new Employee() { EmployeeId = "0013", EmployeeName = "楚十五", DepartmentId = "0001", Title = "Manager" },
            new Employee() { EmployeeId = "0014", EmployeeName = "项十六", DepartmentId = "0002", Title = "Developer" },
            new Employee() { EmployeeId = "0015", EmployeeName = "韩十七", DepartmentId = "0003", Title = "Tester" }
        };
    }
}