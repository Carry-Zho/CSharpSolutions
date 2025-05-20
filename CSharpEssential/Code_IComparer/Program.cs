namespace Code_IComparer
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
