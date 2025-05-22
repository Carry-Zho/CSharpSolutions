namespace Code_IComparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact("John", "d"),
                new Contact("John", "a"),
                new Contact("John", "c"),
                new Contact("John", "b"),

                new Contact("d", "Eecy"),
                new Contact("a", "Eecy"),
                new Contact("c", "Eecy"),
                new Contact("b", "Eecy")

            };

            Console.WriteLine("未Sort");
            foreach (Contact contact in contacts)
                Console.WriteLine($"First name {contact.FirstName},Last name {contact.LastName}");

            Console.WriteLine("使用自定义比较器Sort");
            contacts.Sort(new NameComparision());
            foreach (Contact contact in contacts)
                Console.WriteLine($"First name {contact.FirstName},Last name {contact.LastName}");

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
    internal class NameComparision:IComparer<Contact> 
    {
        public int Compare(Contact? x, Contact? y)
        {
            if(Object.ReferenceEquals(x,y))
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            int result = StringComparer(x.LastName,y.LastName);
            if (result == 0)
                result = StringComparer(x.FirstName, y.FirstName);
            return result;

        }
        private int StringComparer(string x, string y)
        {
            if (Object.ReferenceEquals(x, y))
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.CompareTo(y);
        }
    }
}
