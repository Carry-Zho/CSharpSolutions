namespace Console_PassedByValueOrReference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo demo_First = new Demo() { Field_ObjectName = "demo_First" };
            Demo demo_Second = new Demo() { Field_ObjectName = "demo_Second" };

            Method_PassedByValue(demo_First, demo_Second);
            Console.WriteLine($"demo_First Field_ObjectName:{demo_First.Field_ObjectName} ");
            

            Method_PassedByReference(ref demo_First, ref demo_Second);
            Console.WriteLine($"demo_First Field_ObjectName:{demo_First.Field_ObjectName} ");

        }
        static void Method_PassedByValue(Demo demo1, Demo demo2)
        {
            Console.WriteLine("Method_PassedByValue");
            Console.WriteLine($"demo1 Field_ObjectName:{demo1.Field_ObjectName} ");
            Console.WriteLine($"demo2 Field_ObjectName:{demo2.Field_ObjectName} ");

            demo1 = demo2;

        }

        static void Method_PassedByReference(ref Demo demo1, ref Demo demo2)
        {
            Console.WriteLine("Method_PassedByReference");
            Console.WriteLine($"demo1 Field_ObjectName:{demo1.Field_ObjectName} ");
            Console.WriteLine($"demo2 Field_ObjectName:{demo2.Field_ObjectName} ");

            demo1 = demo2;

        }

        // Demo class
        internal class Demo
        {
            public string Field_ObjectName = string.Empty;
        }
    }
}
