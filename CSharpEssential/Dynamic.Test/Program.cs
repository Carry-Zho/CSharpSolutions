using System.Dynamic;

namespace Dynamic.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpandoObject exobj = new ExpandoObject();
            var exobjDict = exobj as IDictionary<string, object>;
            exobjDict.Add("Name", "John Doe");
            exobjDict.Add("Age", 25);
            Console.WriteLine(exobjDict["Name"]);
            Console.WriteLine(exobjDict["Age"]);
        }
    }
}
