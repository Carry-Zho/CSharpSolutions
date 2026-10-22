namespace Interop_UnsafeCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "S5280ft";

            Console.Write("{0} = ", text);

            unsafe // Require unsafe switch
            {
                fixed (char* pText = text)
                {
                    pText[1] = 'm';
                    pText[2] = 'i';
                    pText[3] = 'l';
                    pText[4] = 'e';
                    pText[5] = ' ';
                    pText[6] = ' ';
                }
            }

            Console.WriteLine("{0}", text);

            text = "S5280ft";
            Console.Write("{0}", text);

        }
    }
}
