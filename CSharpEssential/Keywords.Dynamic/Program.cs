using System.Dynamic;
namespace Keywords.Dynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic person = 10;    //person在运行时被解析为Int32
            Console.WriteLine(person.GetType());

            person.Name = "Alice";  //Int32没有定义Name、Age属性，且不支持动态添加属性，所以会抛出运行时异常
            person.Age = 21;
            Console.WriteLine(person.Age);
        }
    }
}