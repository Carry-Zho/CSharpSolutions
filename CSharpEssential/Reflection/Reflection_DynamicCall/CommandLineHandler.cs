using System;
using System.Diagnostics;
using System.Reflection;

namespace Reflection_DynamicCall
{
    public class CommandLineHandler
    {
        public static bool TryParse(string[] args, object commandLine, out string errorMessage)
        {
            /* Command line demo
             * Compress.exe /Help /Out:<fileName> /Priority:RealTime|High|AbroveNormal|Normal|BellowNormal|Idle
             */

            errorMessage = null;

            //移除命令行参数项的斜线或破折号


            if (args.Any(item => item.ToUpper() == "/Help".ToUpper()))
            {
                //利用反射赋值 commandLine.Help 字段
                PropertyInfo? property = commandLine.GetType().GetProperty("Help");

                if (property?.PropertyType == typeof(bool))
                    property.SetValue(commandLine,true);

                //利用反射调用 commandLine.DisplayHelp() 方法
                Type type = commandLine.GetType();
                MethodInfo? displayMethod = type.GetMethod("DisplayHelp",  BindingFlags.Static | BindingFlags.NonPublic);
                displayMethod?.Invoke(null, null);  //无参调用静态方法
                return true;    //命令行处理程序执行成功
            }

            //处理其他每一项命令


            //命令行参数错误
            errorMessage = "命令行参数错误";
            return false;
        }
    }
}
