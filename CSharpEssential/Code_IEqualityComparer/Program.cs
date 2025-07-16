namespace Code_IEqualityComparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Contact, string> contactDic = new(new ContractEquality());
            Contact c1 = new("John", "Doe");
            Contact c2 = new("John", "Doe");
            Console.WriteLine($"调用Contact类型的默认相等性比较器,c1与c2是否相等 : {c1 == c2}");

            contactDic[c1] = "A";   //添加键值对
            contactDic[c2] = "B";   //检查键c2已存在，更新该键对应的值

            Console.WriteLine($"调用Contact类型的自定义相等性比较器,c1与c2是否相等:{(new ContractEquality()).Equals(c1, c2)}");

            Console.WriteLine($"字典中有几个键值对:{contactDic.Keys.Count}个");
            Console.WriteLine($"键c1的值:{contactDic[c1]}");
            Console.WriteLine($"键c2的值:{contactDic[c2]}");

        }
    }

    internal class Contact
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Contact(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }

    internal class ContractEquality : IEqualityComparer<Contact>
    {
        //无论两个Contract实例是否引用相等，只要它们具有相同的FirstName和LastName属性值，就判定它们是相等的
        public bool Equals(Contact x, Contact y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if((x == null || y == null))
                return false;

            return (x.FirstName == y.FirstName)&&(x.LastName == y.LastName);
        }
        public int GetHashCode(Contact obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;
            int h1 = obj.FirstName == null ? 0 : obj.FirstName.GetHashCode();
            int h2 = obj.LastName == null ? 0 : obj.LastName.GetHashCode();
            return h1*23 +h2;
        }
    }
}
