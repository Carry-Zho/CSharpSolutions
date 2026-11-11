using System;
using System.ComponentModel;
using System.Reflection;

[assembly: Description("Reflection_NameOf")]
[assembly: AssemblyVersion("1.0.0.0")]

[module: Description("Reflection_NameOf")]

namespace Reflection_NameOf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            Print(hello);
        }
        internal static void Print(string printSomething)
        {
            Console.WriteLine(nameof(printSomething));
        }
    }
}
