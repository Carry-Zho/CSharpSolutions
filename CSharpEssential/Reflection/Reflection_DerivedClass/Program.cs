namespace Reflection_DerivedClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(DerivedClass);
            Console.WriteLine("Members of {0}:", t.FullName);
            foreach (var m in t.GetMembers())
            {
                bool hasAttribute = false;
                Console.Write("   {0}: ", m.Name);
                if (m.GetCustomAttributes(typeof(CLSCompliantAttribute), false).Length > 0)
                {
                    Console.Write("CLSCompliant");
                    hasAttribute = true;
                }
                if (m.GetCustomAttributes(typeof(ThreadStaticAttribute), true).Length > 0)
                {
                    Console.Write("ThreadStatic");
                    hasAttribute = true;
                }
                if (!hasAttribute)
                    Console.Write("No attributes");

                Console.WriteLine();
            }
        }
        public class BaseClass
        {
            [ThreadStatic]
            public static int total;

            [CLSCompliant(false)]
            public virtual uint MethodA()
            {
                return (uint)100;
            }
        }
        public class DerivedClass : BaseClass
        {
            public override uint MethodA()
            {
                total++;
                return 200;
            }
        }
    }
}
