using System.Diagnostics;

namespace Reflection_DynamicCall
{
    internal partial class Program
    {
        private class CommandLineInfo  //嵌套的私有类
        {
            public bool Help { get; set; }
            public bool Out { get; set; }
            public ProcessPriorityClass Priority { get; set; } = ProcessPriorityClass.High;

            private static void DisplayHelp() //显示命令行帮助
            {
                /* Command line demo
                 * Compress.exe /Help /Out:<fileName> /Priority:RealTime|High|AbroveNormal|Normal|BellowNormal|Idle
                */

                Console.WriteLine("Compress.exe " +                    
                    "/Help \n" +
                    "/Out:<fileName> \n" +
                    "/Priority:RealTime|High|AbroveNormal|Normal|BellowNormal|Idle");
            }

        }
    }
}
        