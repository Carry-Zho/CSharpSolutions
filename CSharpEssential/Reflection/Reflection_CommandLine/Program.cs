using System.Reflection;

namespace Reflection_CommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type tp = typeof(CommandLineInfo);

            //查询 CommandLineInfo.Help 成员元数据
            MemberInfo[] commandLineInfoHelpMember = tp.GetMember("Help");

            //查询 CommandLineInfo.Help 成员是否应用 CommandLineSwitchAliasAttribute 特性
            Attribute? attribute = commandLineInfoHelpMember[0].GetCustomAttribute(typeof(CommandLineSwitchAliasAttribute), false);
            Console.WriteLine("CommandLineInfo.Help 成员是否应用 CommandLineSwitchAliasAttribute 特性:{0}",attribute != null);

            //查询 CommandLineInfo.Help 成员 CommandLineSwitchAliasAttribute 特性的 Alias 属性值
            Console.WriteLine("CommandLineInfo.Help 成员 CommandLineSwitchAliasAttribute 特性的 Alias 属性值:{0}", ((CommandLineSwitchAliasAttribute)attribute).Alias);

        }
    }

    //自定义特性类型
    public class CommandLineSwitchAliasAttribute : Attribute
    {
        public string Alias { get; private set; }
        public CommandLineSwitchAliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
    
    //定义类，向类的属性成员应用自定义特性
    public class CommandLineInfo
    {
        [CommandLineSwitchAliasAttribute("?")]
        public bool Help { get; set; }        //使用特性实例 Alias == "?" 作为 Help 的别名
    }
}
