using System.Reflection;

namespace Reflection_MyAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the type of MyClass
            Type myType = typeof(MyClass);

            // Get the members associated with MyClass
            MemberInfo[] myMembers = myType.GetMembers();

            // Display the attributes for each of the members of MyClass
            for(int i = 0; i < myMembers.Length; i++)
            {
                object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                if (myAttributes.Length > 0)
                {
                    Console.WriteLine("The attributes for the member {0} are: ", myMembers[i]);
                    for(int j =0;j < myAttributes.Length;j++)
                    {
                        Console.WriteLine("\tThe type of the attribute is {0}.", myAttributes[j]);
                    }
                }
            }
        }
    }

    // Define a custom attribute with one named parameter.
    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute
    {
        private string myName;
        public MyAttribute(string name)
        {
            myName = name;
        }
        public string Name
        {
            get
            {
                return myName;
            }
        }
    }

    // Define a class that has the custom attribute associated with one of its members.
    public class MyClass
    {
        [MyAttribute("This is an example attribute.")]
        public void MyMethod(int i)
        {
            return;
        }
    }
}
