namespace Code_16._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> selection1, selection2;

            ////标准查询操作符
            selection1 = Keywords
                .Where(word => !word.Contains('*'))
                .OrderBy(order => order.Length);

            //查询表达式
            selection2 =
                from word in Keywords
                where !word.Contains('*')
                orderby word.Length
                select word;

            int count = 1;
            foreach (var item in selection1)
            {
                Console.Write("{0,-10}",item);
                if(count % 5 == 0)
                    Console.WriteLine();
                count++;
            }

            Console.WriteLine();
            count = 1;
            foreach (var item in selection2)
            {
                Console.Write("{0,-10}", item);
                if (count % 5 == 0)
                    Console.WriteLine();
                count++;
            }

        }
        static string[] Keywords = {
            "abstract", "add*", "alias*", "as", "ascending*", "async*", 
            "await*", "base","bool", "break", "by*", "byte", "case", 
            "catch", "char", "checked", "class", "const", "continue", 
            "decimal", "default", "delegate", "descending*", "do", 
            "double", "dynamic*", "else", "enum", "event", "equals*", 
            "explicit", "extern", "false", "finally", "fixed", "from*", 
            "float", "for", "foreach", "get*", "global*", "group*", 
            "goto", "if", "implicit", "in", "int", "into*", "interface", 
            "internal", "is", "lock", "long", "join*", "let*", "nameof*", 
            "namespace", "new", "null", "object", "on*", "operator", "orderby*", 
            "out", "override", "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte", 
            "sealed", "select*", "set*", "short", "sizeof", "stackalloc", 
            "static", "string", "struct", "switch", "this", "throw", "true", 
            "try", "typeof", "uint", "ulong", "unsafe", "ushort", "using", 
            "value*", "var*", "virtual", "unchecked", "void", "volatile", 
            "where*", "while", "yield*"
        };
    }
}