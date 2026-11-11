namespace Reflection_FlagsAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileAccess fa = FileAccess.ReadOnly | FileAccess.Hidden;
            //打印标志值，自动转换为打印标志的字符串形式
            Console.WriteLine(fa);

            //从标志值组合的字符串形式解析成枚举
            FileAccess fb;
            fb = (FileAccess)Enum.Parse(typeof(FileAccess), "ReadOnly,Hidden");
            Console.WriteLine(fb);

        }
    }

     public enum FileAccess
    { 
        ReadOnly = 1 << 0,   //1 0001
        Hidden = 1 << 1,    //2 0010
    }
}
