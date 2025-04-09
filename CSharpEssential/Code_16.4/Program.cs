namespace Code_16._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowContextualKeyword2();
        }

        static void ShowContextualKeyword2()
        { 
            IEnumerable<string> selection = 
                from word in Keywords
                where IsKeyword(word)
                select word;

            Console.WriteLine("Query created.");

            foreach(var keyword in selection)
            {
                Console.WriteLine(keyword);
            }

        }

        static bool IsKeyword(string word)
        {
            if (word.Contains('*'))
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return true;
            }
            else 
            {
                return false;
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
