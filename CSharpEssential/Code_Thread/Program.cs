using System.Threading;
namespace Code_Thread
{
    internal class Program
    {
        public const int Repetitions = 1000;
        static void Main(string[] args)
        {
            ThreadStart threadStart = DoWork;
            Thread thread = new Thread(threadStart);
            thread.Start(); //启动线程
            for(int count = 0; count < Repetitions; count++)
            {
                Console.Write("-");
            }
            thread.Join(); //等待线程结束
        }
        public static void DoWork()
        {
            for(int count = 0; count < Repetitions; count++)
            {
                Console.Write("+");
            }
        }
    }
}
