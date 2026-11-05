using System.Diagnostics;

namespace Reflection_DynamicCall
{
    internal partial class Program
    {
       
        static void Main(string[] args)
        {
            /* Command line demo
             * Compress.exe /Help /Out:<fileName> /Priority:RealTime|High|AbroveNormal|Normal|BellowNormal|Idle
             */


            string errorMessage;

            CommandLineInfo commandLine = new CommandLineInfo(); //创建 commandLine对象，默认初始化 Help:false Out:false ProcessPriorityClass:ProcessPriorityClass.High

            //调用命令行处理程序

            if (!CommandLineHandler.TryParse(args, commandLine, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;  //命令行参数错误，中断执行
            }

            Console.WriteLine("Goooood");

        }
    }

}
