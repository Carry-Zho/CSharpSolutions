#define CONDITION_A   //定义条件编译符号 CONDITION_A，执行 MethodA
using System.Diagnostics;
namespace Reflection_ConditionalAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            MethodA();
            MethodB();
            Console.WriteLine("End");
        }

        [Conditional("CONDITION_A")]
        static void MethodA()
        {
            Console.WriteLine("MethodA executing...");
        }

        [Conditional("CONDITION_B")]
        static void MethodB()
        {
            Console.WriteLine("Methodd executing...");
        }
    }
}
